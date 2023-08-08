using System.Collections;
using System.Collections.Generic;
using Game.Ship.Shots.Shot;
using UnityEngine;
using Utilities;

namespace Game.Ship
{
    public class ShipPresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly ShipModel _model;
        private readonly ShipView _view;

        private readonly Dictionary<ShotModel, ShotPresenter> _shotsPresenters = new();
        private readonly Dictionary<ShotModel, ShotView> _activeShots = new();
        private readonly List<ShotModel> _inActiveShots = new();
        
        private Coroutine _reloadCoroutine;
        private Coroutine _shotRateCoroutine;

        public ShipPresenter(GameEnvironment environment, ShipModel model, ShipView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            CreateShotsPull();
            
            _model.ShotsLeft = _model.Specification.Count;            
            _model.IsReadyToShoot = true;
            
            _model.OnShoot += CreateBullet;
            _model.OnUpdate += Update;
        }
        
        public void Deactivate()
        {
            _model.OnShoot -= CreateBullet;
            _model.OnUpdate -= Update;
        }

        private void Update(float deltaTime)
        {
            foreach (var model in _inActiveShots)
            {
                DestroyShot(model);
            }
            
            _inActiveShots.Clear();

            foreach (var model in _activeShots.Keys)
            {
                var zoneLimits = _environment.GameSceneView.GameView.ZoneLimits;

                if (!(model.Position.x <= zoneLimits.LeftSide) && !(model.Position.x >= zoneLimits.RightSide) && !(model.Position.z >= zoneLimits.TopSide)) continue;
                
                if (!_inActiveShots.Contains(model))
                {
                    _inActiveShots.Add(model);
                }
            }
            
            foreach (var model in _activeShots.Keys)
            {
                model.Update(deltaTime);
            }
        }

        private void CreateBullet()
        {
            if (!_environment.InputModel.IsShipShooting || _model.IsReloading || _model.ShotsLeft == 0) return;

            _model.IsReadyToShoot = false;
            
            var shotModel = new ShotModel(_view.transform.position, _model.Specification.ShotPrefab.Speed);
            var shotView = _environment.PullsData.ShotsPull.TryGetElement();
            var presenter = new ShotPresenter(_environment, shotModel, shotView);
            
            presenter.Activate();
            
            _shotsPresenters.Add(shotModel, presenter);
            _activeShots.Add(shotModel, shotView);
            
            _shotRateCoroutine = GameCoroutines.RunCoroutine(WaitForFireRate(_model.Specification.ShotRate));

            if (!_model.Specification.IsAutomatic)
            {
                _model.ShotsLeft--;

                if (_model.ShotsLeft <= 0)
                {
                    _model.IsReadyToShoot = false;
                    _reloadCoroutine = GameCoroutines.RunCoroutine(WaitForReload(_model.Specification.ReloadTime));
                }    
            }
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
            
            _model.ShotsLeft = _model.Specification.Count;
            _model.IsReadyToShoot = true;
            
            GameCoroutines.DisableCoroutine(_reloadCoroutine);
            _reloadCoroutine = null;
        }

        private void CreateShotsPull()
        {
            var shotsPull = _environment.GameSceneView.GameView.ShotsPullView;
            
            shotsPull.ElementPrefab = _model.Specification.ShotPrefab;
            shotsPull.Count = _model.Specification.Count;
            
            _environment.PullsData.ShotsPull.CreatePull(shotsPull);   
        }

        private void DestroyShot(ShotModel model)
        {
            _shotsPresenters[model].Deactivate();
            _shotsPresenters.Remove(model);
            
            _environment.PullsData.ShotsPull.PutBack(_activeShots[model]);
            _activeShots.Remove(model);
        }
    }
}