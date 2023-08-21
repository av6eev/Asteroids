using System.Collections;
using System.Collections.Generic;
using Game.Ship.Bullet;
using Global;
using UnityEngine;
using Utilities;

namespace Game.Ship.Shoot
{
    public class ShipShootPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly ShipShootModel _model;

        private readonly List<BulletModel> _inActiveBullets = new();
        private readonly Dictionary<BulletModel, BulletPresenter> _bulletsPresenters = new();
        
        private Coroutine _reloadCoroutine;
        private Coroutine _shotRateCoroutine;
        
        public ShipShootPresenter(GlobalEnvironment environment, ShipShootModel model)
        {
            _environment = environment;
            _model = model;
        }
        
        public void Activate()
        {
            CreateBulletsPull();

            _model.IsReadyToShoot = true;
            
            _environment.ShipModel.OnShoot += CreateBullet;
            _model.OnUpdate += Update;
            _model.OnBulletDestroyed += DestroyBullet;
        }

        public void Deactivate()
        {
            _environment.ShipModel.OnShoot -= CreateBullet;
            _model.OnUpdate -= Update;
            _model.OnBulletDestroyed -= DestroyBullet;
            
            Debug.Log(nameof(ShipShootPresenter) + " deactivated!");
        }

        private void Update(float deltaTime)
        {
            foreach (var model in _inActiveBullets)
            {
                DestroyBullet(model);
            }
            
            _inActiveBullets.Clear();

            var activeBullets = _model.GetActiveBullets();
            
            foreach (var model in activeBullets.Keys)
            {
                var zoneLimits = _environment.GameSceneView.GameView.ZoneLimits;

                if (!(model.Position.x <= zoneLimits.LeftSide) && !(model.Position.x >= zoneLimits.RightSide) && !(model.Position.z >= zoneLimits.TopSide)) continue;
                
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
            
            var shotModel = new BulletModel(_environment.GameSceneView.GameView.CurrentShip.transform.position, _model.BulletSpeed, _model.BulletHealth, _model.BulletDamage);
            var shotView = _environment.PullsData.BulletsPull.TryGetElement();
            var presenter = new BulletPresenter(_environment, shotModel, shotView);
            
            presenter.Activate();
            
            _bulletsPresenters.Add(shotModel, presenter);
            _model.AddActiveBullet(shotModel, shotView);
            
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
            
            _environment.PullsData.BulletsPull.PutBack(_model.GetByKey(model));
            
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
            var bulletsPull = _environment.GameSceneView.GameView.BulletsPullView;
            
            bulletsPull.ElementPrefab = _environment.ShipModel.Specification.BulletPrefab;
            bulletsPull.Count = _model.StartBulletCount;
            
            _environment.PullsData.BulletsPull.CreatePull(bulletsPull);   
        }
    }
}