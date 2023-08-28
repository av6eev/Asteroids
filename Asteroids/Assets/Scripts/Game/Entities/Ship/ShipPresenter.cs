using System.Collections;
using Game.Entities.Ship.Base;
using Game.Entities.Ship.Move;
using Game.Entities.Ship.Rotate;
using Game.Entities.Ship.Shoot;
using Global;
using UnityEngine;
using Utilities;

namespace Game.Entities.Ship
{
    public class ShipPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly ShipModel _model;
        private BaseShipView _view;

        private readonly PresentersEngine _presenters = new();
        private Coroutine _immunityCoroutine;

        public ShipPresenter(GlobalEnvironment environment, ShipModel model, BaseShipView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            CreateNecessaryData();
            
            _model.OnDamageApplied += ApplyDamage;
            _model.OnViewChanged += RedrawShip;
            _model.OnDestroy += EndGame;
        }

        public void Deactivate()
        {
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.ShipMove);
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.ShipShoot);
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.ShipRotate);
            
            _presenters.Deactivate();
            _presenters.Clear();

            _model.OnDamageApplied -= ApplyDamage;
            _model.OnViewChanged -= RedrawShip;
            _model.OnDestroy -= EndGame;
            
            Debug.Log(nameof(ShipPresenter) + " deactivated!");
        }

        private void ApplyDamage()
        {
            _model.UpdateImmuneState(true);
            _immunityCoroutine = GameCoroutines.RunCoroutine(EnableImmunity());
            _view.EnableImmunity();
        }

        private void EndGame() => _environment.GameModel.End();

        private void RedrawShip(BaseShipView newShipView) => _view = newShipView;

        private IEnumerator EnableImmunity()
        {
            var currentTime = 0f;
            
            while (currentTime < 3f)
            {
                currentTime += 1f;
                yield return new WaitForSeconds(1);
            }

            _model.UpdateImmuneState(false);
            GameCoroutines.DisableCoroutine(_immunityCoroutine);
            _immunityCoroutine = null;
        }

        private void CreateNecessaryData()
        {
            var specification = _model.Specification;
            var hitsPull = _environment.GameSceneView.GameView.HitsPullView;
            
            _model.ShootModel = new ShipShootModel(specification.Count, specification.ReloadTime, specification.ShootRate, specification.IsAutomatic, specification.BulletPrefab2D.Health, specification.BulletPrefab2D.Damage);
            _model.MoveModel = new ShipMoveModel(specification.Speed);
            _model.RotateModel = new ShipRotateModel();
            
            _presenters.Add(new ShipMovePresenter(_environment, _model.MoveModel));
            _presenters.Add(new ShipShootPresenter(_environment, _model.ShootModel));
            _presenters.Add(new ShipRotatePresenter(_environment, _model.RotateModel));
            _presenters.Activate();
            
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.ShipMove, new ShipMoveUpdater());
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.ShipShoot, new ShipShootUpdater());
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.ShipRotate, new ShipRotateUpdater());
            
            hitsPull.ElementPrefab = _environment.ShipModel.Specification.BulletPrefab2D.HitEffect;
            hitsPull.Count = 10;
            
            _environment.PullsData.HitsPull.CreatePull(hitsPull);
        }
    }
}