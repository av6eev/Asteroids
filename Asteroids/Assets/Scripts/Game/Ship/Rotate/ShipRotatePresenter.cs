using Global;
using UnityEngine;
using Utilities;

namespace Game.Ship.Rotate
{
    public class ShipRotatePresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly ShipRotateModel _model;

        private const float ROTATE_MULTIPLIER = 4f;
        
        public ShipRotatePresenter(GlobalEnvironment environment, ShipRotateModel model)
        {
            _environment = environment;
            _model = model;
        }
        
        public void Activate() => _model.OnUpdate += Update;

        public void Deactivate()
        {
            _model.OnUpdate -= Update;
            
            Debug.Log(nameof(ShipRotatePresenter) + " deactivated!");
        }

        private void Update(float deltaTime) => Rotate(deltaTime);

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
    }
}