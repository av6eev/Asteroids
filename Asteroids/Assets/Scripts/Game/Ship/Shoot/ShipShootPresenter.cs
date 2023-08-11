using System.Collections;
using System.Collections.Generic;
using Game.Ship.Shots;
using UnityEngine;
using Utilities;

namespace Game.Ship.Shoot
{
    public class ShipShootPresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly ShipShootModel _model;

        private readonly Dictionary<BulletModel, BulletView> _activeBullets = new();
        private readonly List<BulletModel> _inActiveBullets = new();
        private readonly Dictionary<BulletModel, BulletPresenter> _bulletsPresenters = new();
        
        private Coroutine _reloadCoroutine;
        private Coroutine _shotRateCoroutine;
        
        public ShipShootPresenter(GameEnvironment environment, ShipShootModel model)
        {
            _environment = environment;
            _model = model;
        }
        
        public void Activate()
        {
            CreateShotsPull();

            _model.IsReadyToShoot = true;
            
            _environment.ShipModel.OnShoot += CreateBullet;
            _model.OnUpdate += Update;
        }

        public void Deactivate()
        {
            _environment.ShipModel.OnShoot -= CreateBullet;
            _model.OnUpdate -= Update;
        }

        private void Update(float deltaTime)
        {
            foreach (var model in _inActiveBullets)
            {
                DestroyShot(model);
            }
            
            _inActiveBullets.Clear();

            foreach (var model in _activeBullets.Keys)
            {
                var zoneLimits = _environment.GameSceneView.GameView.ZoneLimits;

                if (!(model.Position.x <= zoneLimits.LeftSide) && !(model.Position.x >= zoneLimits.RightSide) && !(model.Position.z >= zoneLimits.TopSide)) continue;
                
                if (!_inActiveBullets.Contains(model))
                {
                    _inActiveBullets.Add(model);
                }
            }
            
            foreach (var model in _activeBullets.Keys)
            {
                model.Update(deltaTime);
            }
        }
        
        private void CreateBullet()
        {
            if (!_environment.InputModel.IsShipShooting || _model.IsReloading || _model.ShotsLeft == 0 || !_model.IsReadyToShoot) return;

            _model.IsReadyToShoot = false;
            
            var shotModel = new BulletModel(_environment.GameSceneView.GameView.CurrentShip.transform.position, _model.BulletSpeed);
            var shotView = _environment.PullsData.ShotsPull.TryGetElement();
            var presenter = new BulletPresenter(_environment, shotModel, shotView);
            
            presenter.Activate();
            
            _bulletsPresenters.Add(shotModel, presenter);
            _activeBullets.Add(shotModel, shotView);
            
            _shotRateCoroutine = GameCoroutines.RunCoroutine(WaitForFireRate(_model.ShotRate));

            if (!_model.IsAutomatic)
            {
                _model.ShotsLeft--;

                if (_model.ShotsLeft <= 0)
                {
                    _model.IsReadyToShoot = false;
                    _reloadCoroutine = GameCoroutines.RunCoroutine(WaitForReload(_model.ReloadTime));
                }    
            }
        }
        
        private void CreateShotsPull()
        {
            var shotsPull = _environment.GameSceneView.GameView.ShotsPullView;
            
            shotsPull.ElementPrefab = _environment.ShipModel.Specification.BulletPrefab;
            shotsPull.Count = _model.StartBulletCount;
            
            _environment.PullsData.ShotsPull.CreatePull(shotsPull);   
        }
        
        private void DestroyShot(BulletModel model)
        {
            _bulletsPresenters[model].Deactivate();
            _bulletsPresenters.Remove(model);
            
            _environment.PullsData.ShotsPull.PutBack(_activeBullets[model]);
            _activeBullets.Remove(model);
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
            
            _model.ShotsLeft = _model.StartBulletCount;
            _model.IsReadyToShoot = true;
            
            GameCoroutines.DisableCoroutine(_reloadCoroutine);
            _reloadCoroutine = null;
        }
    }
}