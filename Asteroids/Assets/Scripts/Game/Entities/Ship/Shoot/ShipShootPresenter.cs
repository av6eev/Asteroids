using System.Collections;
using System.Collections.Generic;
using Game.Entities.Bullet;
using Game.Entities.Bullet.Base;
using Global;
using UnityEngine;
using Utilities;
using Utilities.Enums;
using Utilities.Game;
using Utilities.Interfaces;

namespace Game.Entities.Ship.Shoot
{
    public class ShipShootPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly ShipShootModel _model;

        private readonly List<BulletModel> _inActiveBullets = new();
        private readonly Dictionary<BulletModel, BulletPresenter> _bulletsPresenters = new();
        
        private Coroutine _reloadCoroutine;
        private Coroutine _shotRateCoroutine;
        private bool _isPaused;

        public ShipShootPresenter(GlobalEnvironment environment, ShipShootModel model)
        {
            _environment = environment;
            _model = model;
        }

        public void Activate()
        {
            CreateBulletsPull();

            _model.IsReadyToShoot = true;

            _model.OnUpdate += Update;
            _model.OnBulletDestroyed += DestroyBullet;
            _model.OnShoot += CreateBullet;
            
            _environment.GameModel.OnDimensionChanged += ChangeActivePulls;
        }

        public void Deactivate()
        {
            _model.OnUpdate -= Update;
            _model.OnBulletDestroyed -= DestroyBullet;
            _model.OnShoot -= CreateBullet;
            
            _environment.GameModel.OnDimensionChanged -= ChangeActivePulls;
        }

        private void ChangeActivePulls()
        {
            _isPaused = true;

            foreach (var bullet in _model.GetActiveBullets().Values)
            {
                switch (_environment.GameModel.CurrentDimension)
                {
                    case CameraDimensionsTypes.TwoD:
                        _environment.PullsData.BulletsPull3D.PutBack((BulletView3D)bullet);
                        break;
                    case CameraDimensionsTypes.ThreeD:
                        _environment.PullsData.BulletsPull2D.PutBack((BulletView2D)bullet);
                        break;
                }
            }

            foreach (var presenter in _bulletsPresenters.Values)
            {
                presenter.Deactivate();
            }
            
            _bulletsPresenters.Clear();
            _inActiveBullets.Clear();
            _model.ResetActiveBullets();

            _isPaused = false;
        }

        private void Update(float deltaTime)
        {
            if (_isPaused) return;
            
            foreach (var model in _inActiveBullets)
            {
                DestroyBullet(model);
            }
            
            _inActiveBullets.Clear();

            var activeBullets = _model.GetActiveBullets();
            
            foreach (var model in activeBullets.Keys)
            {
                if (CheckIntersects(model)) continue;
                
                if (!_inActiveBullets.Contains(model))
                {
                    _inActiveBullets.Add(model);
                }
            }
            
            foreach (var model in activeBullets.Keys)
            {
                model.Update(deltaTime);
            }
        }
        
        private void CreateBullet()
        {
            if (!_environment.InputModel.IsShipShooting || _model.IsReloading || _model.BulletsLeft == 0 || !_model.IsReadyToShoot) return;

            _model.IsReadyToShoot = false;
            
            var model = new BulletModel(_environment.ShipModel.MoveModel.Position, _model.BulletHealth, _model.BulletDamage);
            
            BaseBulletView view = _environment.GameModel.CurrentDimension switch
            {
                CameraDimensionsTypes.TwoD => _environment.PullsData.BulletsPull2D.TryGetElement(),
                CameraDimensionsTypes.ThreeD => _environment.PullsData.BulletsPull3D.TryGetElement(),
                _ => null
            };
            
            var presenter = new BulletPresenter(_environment, model, view);
            
            presenter.Activate();
            
            _bulletsPresenters.Add(model, presenter);
            _model.AddActiveBullet(model, view);
            
            _shotRateCoroutine = GameCoroutines.RunCoroutine(WaitForFireRate(_model.ShootRate));

            if (!_model.IsAutomatic)
            {
                _model.BulletsLeft--;

                if (_model.BulletsLeft <= 0)
                {
                    _model.IsReadyToShoot = false;
                    _model.IsReloading = true;
                    
                    _reloadCoroutine = GameCoroutines.RunCoroutine(WaitForReload(_model.ReloadTime));
                }    
            }
        }

        private void DestroyBullet(BulletModel model)
        {
            _bulletsPresenters[model].Deactivate();
            _bulletsPresenters.Remove(model);
            
            switch (_environment.GameModel.CurrentDimension)
            {
                case CameraDimensionsTypes.TwoD:
                    _environment.PullsData.BulletsPull2D.PutBack((BulletView2D)_model.GetByKey(model));
                    break;
                case CameraDimensionsTypes.ThreeD:
                    _environment.PullsData.BulletsPull3D.PutBack((BulletView3D)_model.GetByKey(model));
                    break;
            }
            
            _model.RemoveActiveBullet(model);
        }

        private IEnumerator WaitForFireRate(float shotRate)
        {
            yield return new WaitForSeconds(shotRate);
            
            _model.IsReadyToShoot = true;
            
            GameCoroutines.DisableCoroutine(_shotRateCoroutine);
            _shotRateCoroutine = null;
        }

        private IEnumerator WaitForReload(float reloadTime)
        {
            yield return new WaitForSeconds(reloadTime);
            
            _model.BulletsLeft = _model.StartBulletCount;
            _model.IsReadyToShoot = true;
            _model.IsReloading = false;
            
            GameCoroutines.DisableCoroutine(_reloadCoroutine);
            _reloadCoroutine = null;
        }

        private void CreateBulletsPull()
        {
            var bulletsPull3D = _environment.GameSceneView.GameView.BulletsPullView3D;
            var bulletsPull2D = _environment.GameSceneView.GameView.BulletsPullView2D;

            bulletsPull3D.ElementPrefab = _environment.ShipModel.Specification.BulletPrefab3D;
            bulletsPull2D.ElementPrefab = _environment.ShipModel.Specification.BulletPrefab2D;
            
            bulletsPull3D.Count = _model.StartBulletCount;
            bulletsPull2D.Count = _model.StartBulletCount;
            
            _environment.PullsData.BulletsPull3D.CreatePull(bulletsPull3D);             
            _environment.PullsData.BulletsPull2D.CreatePull(bulletsPull2D);   
        }
        
        private bool CheckIntersects(BulletModel model)
        {
            var zoneLimits = _environment.GameModel.ZoneLimits;
            
            return _environment.GameModel.CurrentDimension switch
            {
                CameraDimensionsTypes.TwoD => !(model.Position.x <= zoneLimits.LeftSide) &&
                                              !(model.Position.x >= zoneLimits.RightSide) &&
                                              !(model.Position.y >= zoneLimits.TopSide),
                CameraDimensionsTypes.ThreeD => !(model.Position.x < zoneLimits.LeftSide) &&
                                                !(model.Position.x > zoneLimits.RightSide) &&
                                                !(model.Position.z >= zoneLimits.TopSide),
                _ => default
            };
        }
    }
}