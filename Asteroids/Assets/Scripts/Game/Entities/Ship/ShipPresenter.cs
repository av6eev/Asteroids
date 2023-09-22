using System.Collections;
using Game.Entities.Ship.Base;
using Game.Entities.Ship.Move;
using Game.Entities.Ship.Rotate;
using Game.Entities.Ship.Shoot;
using Global;
using UnityEngine;
using Utilities.Engines;
using Utilities.Enums;
using Utilities.Game;
using Utilities.Interfaces;

namespace Game.Entities.Ship
{
    public class ShipPresenter : IPresenter
    {
        private readonly IGlobalEnvironment _environment;
        private readonly IShipModel _model;
        private readonly IShipView _view;

        private readonly PresentersEngine _presenters = new();
        private Coroutine _immunityCoroutine;

        public ShipPresenter(IGlobalEnvironment environment, IShipModel model, IShipView view)
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
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.ShipRotate);
            
            _presenters.Deactivate();
            _presenters.Clear();

            _model.OnDamageApplied -= ApplyDamage;
        }

        private void ApplyDamage()
        {
            _environment.GameModel.UpdateLives(_model.CurrentHealth);
            
            _model.UpdateImmuneState(true);
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

            _model.UpdateImmuneState(false);
            GameCoroutines.DisableCoroutine(_immunityCoroutine);
            _immunityCoroutine = null;
        }

        private void CreateNecessaryData()
        {
            _presenters.Add(new ShipMovePresenter(_environment, _model.MoveModel));
            _presenters.Add(new ShipShootPresenter(_environment, _model.ShootModel));
            _presenters.Add(new ShipRotatePresenter(_environment, _model.RotateModel));
            
            _presenters.Activate();
            
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.ShipMove, new ShipMoveUpdater());
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.ShipShoot, new ShipShootUpdater());
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.ShipRotate, new ShipRotateUpdater());
        }
    }
}