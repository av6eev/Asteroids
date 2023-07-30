using Game.Ship;
using UnityEngine;
using Utilities;

namespace Game.Systems
{
    public class ShipMovementSystem : ISystem
    {
        private const float ROTATE_AMOUNT = 15f;
        private const float ROTATE_SPEED = 10f;
        
        public void Update(GameEnvironment environment)
        {
            var currentShip = environment.GameSceneView.GameView.CurrentShip;
            
            MoveTowards(environment.ShipModel, currentShip);            
            RotateAndTurn(environment, currentShip.transform);
        }

        private void MoveTowards(ShipModel shipModel, ShipView shipView)
        {
            shipView.Rigidbody.AddForce(shipView.transform.forward * (shipModel.Specification.Speed * Time.deltaTime), ForceMode.Impulse);
        }

        private void RotateAndTurn(GameEnvironment environment, Transform shipView)
        {
            var inputModel = environment.InputModel;
            
            if (!inputModel.IsShipRotating) return;
            
            switch (inputModel.ShipRotateDirection)
            {
                case 1.0f:
                    shipView.Rotate(new Vector3(0, 0, -ROTATE_AMOUNT) * (ROTATE_SPEED * Time.deltaTime));
                    
                    break;
                case -1.0f:
                    shipView.Rotate(new Vector3(0, 0, ROTATE_AMOUNT) * (ROTATE_SPEED * Time.deltaTime));
                    break;
            }
        }
    }
}