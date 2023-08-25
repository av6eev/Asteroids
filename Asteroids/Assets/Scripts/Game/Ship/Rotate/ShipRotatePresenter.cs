using Global;
using UnityEngine;
using Utilities;

namespace Game.Ship.Rotate
{
    public class ShipRotatePresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly ShipRotateModel _model;

        private const float ROTATE_SIDE_VALUE = 8f;
        
        public ShipRotatePresenter(GlobalEnvironment environment, ShipRotateModel model)
        {
            _environment = environment;
            _model = model;
        }
        
        public void Activate()
        {
            _model.OnUpdate += Update;
        }

        public void Deactivate()
        {
            _model.OnUpdate -= Update;
        }

        private void Update(float deltaTime)
        {
            Rotate(deltaTime);
        }

        private void Rotate(float deltaTime)
        {
            var shipView = _environment.GameSceneView.GameView.CurrentShip;
            
            var direction = new Vector3(0,0,0)
            {
                z = _environment.InputModel.ShipTurnDirection switch
                {
                    1.0f => ROTATE_SIDE_VALUE,
                    -1.0f => -ROTATE_SIDE_VALUE,
                    _ => 0f
                }
            };

            direction.z = direction.z < 0 ? Mathf.Clamp(direction.z, -45f, 0f) : Mathf.Clamp(direction.z, 0, 45f) * deltaTime;

            // shipView.Rotate(direction);
        }
    }
}