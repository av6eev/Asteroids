using System.Collections;
using System.Collections.Generic;
using Game.Entities.Bullet;
using Game.Entities.Bullet.Base;
using Game.Factories.Bullet;
using Game.Factories.Bullet.Base;
using Global;
using Global.Base;
using UnityEngine;
using Utilities.Enums;
using Utilities.Game;
using Utilities.Interfaces;

namespace Game.Entities.Ship.Shoot
{
    public class ShipShootPresenter : IPresenter
    {
        private readonly IGlobalEnvironment _environment;
        private readonly ShipShootModel _model;

        private readonly List<IBulletModel> _inActiveBullets = new();
        private readonly Dictionary<IBulletModel, BulletPresenter> _bulletsPresenters = new();

        private BaseBulletModelFactory _bulletModelFactory;
        
        private Coroutine _reloadCoroutine;
        private Coroutine _shotRateCoroutine;

        public ShipShootPresenter(IGlobalEnvironment environment, ShipShootModel model)
        {
            _environment = environment;
            _model = model;
        }

        public void Activate()
        {
            _model.IsReadyToShoot = true;
            
            _bulletModelFactory = _environment.GameModel.CurrentDimension switch
            {
                CameraDimensionsTypes.TwoD => new BulletModel2DFactory(),
                CameraDimensionsTypes.ThreeD => new BulletModel3DFactory(),
                _ => _bulletModelFactory
            };

            _model.OnUpdate += Update;
            _model.OnBulletDestroyed += DestroyBullet;
            _model.OnShoot += CreateBullet;
        }

        public void Deactivate()
        {
            _inActiveBullets.Clear();
            _model.ResetActiveBullets();

            foreach (var presenter in _bulletsPresenters.Values)
            {
                presenter.Deactivate();
            }
            
            _bulletsPresenters.Clear();
            
            _model.OnUpdate -= Update;
            _model.OnBulletDestroyed -= DestroyBullet;
            _model.OnShoot -= CreateBullet;
        }

        private void Update(float deltaTime)
        {
            foreach (var model in _inActiveBullets)
            {
                DestroyBullet(model);
            }
            
            _inActiveBullets.Clear();

            foreach (var model in _model.GetActiveBullets().Keys)
            {
                if (model.CheckIntersects(_environment.GameModel.ZoneLimits))
                {
                    model.Update(deltaTime);
                    continue;
                }
                
                if (!_inActiveBullets.Contains(model))
                {
                    _inActiveBullets.Add(model);
                }
            }
        }
        
        private void CreateBullet()
        {
            if (!_environment.InputModel.IsShipShooting || _model.IsReloading || _model.BulletsLeft == 0 || !_model.IsReadyToShoot) return;

            _model.IsReadyToShoot = false;
            
            var view = _environment.PullsModel.BulletsPull.TryGetElement(); 
            var model = _bulletModelFactory.Create(_environment.GameSceneView.GameView.CurrentShip.BulletSpawnPoint.position, _model.BulletHealth, _model.BulletDamage);
            var presenter = new BulletPresenter(_environment, model, view);
            
            presenter.Activate();
            
            if (model == null) return;
            
            _bulletsPresenters.Add(model, presenter);
            _model.AddActiveBullet(model, view);
            
            _shotRateCoroutine = GameCoroutines.RunCoroutine(WaitForFireRate(_model.ShootRate));

            if (_model.IsAutomatic) return;
            
            _model.BulletsLeft--;

            if (_model.BulletsLeft > 0) return;
            
            _model.IsReadyToShoot = false;
            _model.IsReloading = true;
                    
            _reloadCoroutine = GameCoroutines.RunCoroutine(WaitForReload(_model.ReloadTime));
        }

        private void DestroyBullet(IBulletModel model)
        {
            _bulletsPresenters[model].Deactivate();
            _bulletsPresenters.Remove(model);
            
            _environment.PullsModel.BulletsPull.PutBack(_model.GetByKey(model));
            
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
    }
}