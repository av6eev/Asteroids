using System;
using System.Collections;
using Game.Ship.Move;
using Game.Ship.Shoot;
using Global;
using UnityEngine;
using Utilities;
using Environment = UnityEditor.Rendering.LookDev.Environment;

namespace Game.Ship
{
    public class ShipPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly ShipModel _model;
        private readonly ShipView _view;

        private readonly PresentersEngine _presenters = new();
        private Coroutine _immunityCoroutine;

        public ShipPresenter(GlobalEnvironment environment, ShipModel model, ShipView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            CreateNecessaryData();

            _model.OnDamageApplied += ApplyDamage;
        }
        
        public void Deactivate()
        {
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.ShipMove);
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.ShipShoot);
            
            _presenters.Deactivate();
            _presenters.Clear();

            _model.OnDamageApplied -= ApplyDamage;
            
            Debug.Log(nameof(ShipPresenter) + " deactivated!");
        }

        private void ApplyDamage()
        {
            _model.Health--;

            if (_model.Health <= 0)
            {
                _environment.GameModel.EndGame();
                return;
            }

            _model.IsImmune = true;
            _immunityCoroutine = GameCoroutines.RunCoroutine(EnableImmunity());
            _view.EnableImmunity();
        }

        private IEnumerator EnableImmunity()
        {
            var currentTime = 0f;
            
            while (currentTime < 3f)
            {
                currentTime += 1f;
                yield return new WaitForSeconds(1);
            }
            
            _model.IsImmune = false;
            GameCoroutines.DisableCoroutine(_immunityCoroutine);
            _immunityCoroutine = null;
        }

        private void CreateNecessaryData()
        {
            var specification = _model.Specification;
            var hitsPull = _environment.GameSceneView.GameView.HitsPullView;
            
            _model.ShootModel = new ShipShootModel(specification.Count, specification.ReloadTime, specification.ShootRate, specification.IsAutomatic, specification.BulletPrefab.Speed, specification.BulletPrefab.Health, specification.BulletPrefab.Damage);
            _model.MoveModel = new ShipMoveModel(specification.Speed);
            
            _presenters.Add(new ShipMovePresenter(_environment, _model.MoveModel));
            _presenters.Add(new ShipShootPresenter(_environment, _model.ShootModel));
            _presenters.Activate();
            
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.ShipMove, new ShipMoveUpdater());
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.ShipShoot, new ShipShootUpdater());
            
            hitsPull.ElementPrefab = _environment.ShipModel.Specification.BulletHitParticleSystem;
            hitsPull.Count = 10;
            
            _environment.PullsData.HitsPull.CreatePull(hitsPull);
        }
    }
}