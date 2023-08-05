using Game.Ship;
using UnityEngine;
using Utilities;

namespace Game.Systems
{
    public class ShipMovementSystem : ISystem
    {
        private const float ROTATE_AMOUNT = 15f;
        private const float ROTATE_SPEED = 20f;
        private const float MOVE_FORWARD_VALUE = 10f;
        private const float TURN_SIDE_VALUE = 10f;
        
        public void Update(GameEnvironment environment)
        {
            var currentShip = environment.GameSceneView.GameView.CurrentShip;
            
            Move(environment, currentShip);
        }

        private void Move(GameEnvironment environment, ShipView shipView)
        {
            var inputModel = environment.InputModel;
            var shipTransform = shipView.transform;
            
            if (!inputModel.IsShipRotating)
            {
                shipTransform.Translate(new Vector3(0,0,MOVE_FORWARD_VALUE) * (environment.ShipModel.Specification.Speed * Time.deltaTime));
                return;
            }

            var turnDirection = inputModel.ShipRotateDirection switch
            {
                1.0f => Vector3.right * TURN_SIDE_VALUE,
                -1.0f => Vector3.left * TURN_SIDE_VALUE,
                _ => Vector3.zero
            };

            shipTransform.Translate(turnDirection * (environment.ShipModel.Specification.Speed * Time.deltaTime));
            
            var shipPosition = shipTransform.position;
            var x = shipPosition.x;
            
            switch (x)
            {
                case > GameZoneLimits.RightSide:
                    x -= GameZoneLimits.RightSide * 2;
                    break;
                case < GameZoneLimits.LeftSide:
                    x += Mathf.Abs(GameZoneLimits.LeftSide * 2);
                    break;
            }

            shipPosition.x = x;
            shipView.transform.position = shipPosition;
        }
    }
}