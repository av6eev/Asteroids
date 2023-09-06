using Global;
using UnityEngine;
using Utilities;
using Utilities.Interfaces;

namespace Game.Entities.Ship.Rotate
{
    public class ShipRotatePresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly ShipRotateModel _model;
        private bool _isPaused;

        private const float ROTATE_MULTIPLIER = 4f;
        
        public ShipRotatePresenter(GlobalEnvironment environment, ShipRotateModel model)
        {
            _environment = environment;
            _model = model;
        }
        
        public void Activate()
        {
            _model.OnUpdate += Update;
            
            _environment.ShipModel.OnActionsPaused += PauseActions;
            _environment.ShipModel.OnActionsContinued += ContinueActions;
        }

        public void Deactivate()
        {
            _model.OnUpdate -= Update;
            
            _environment.ShipModel.OnActionsPaused -= PauseActions;
            _environment.ShipModel.OnActionsContinued -= ContinueActions;
        }

        private void Update(float deltaTime)
        {
            if (_isPaused) return;
            
            Rotate(deltaTime);
        }

        private void Rotate(float deltaTime)
        {
            var shipView = _environment.GameSceneView.GameView.CurrentShip;
            var turnDirection = -_environment.InputModel.ShipTurnDirection * ROTATE_MULTIPLIER;
            turnDirection = Mathf.Clamp(turnDirection, -45f, 45f);

            if (_model.TryUpdateRotation(turnDirection, out var sumRotation))
            {
                shipView.Rotate(sumRotation);
            }

            if (turnDirection == 0)
            {
                _model.ResetRotation(shipView.ResetRotation());
            }
        }
        
        private void ContinueActions() => _isPaused = false;

        private void PauseActions() => _isPaused = true;
    }
}