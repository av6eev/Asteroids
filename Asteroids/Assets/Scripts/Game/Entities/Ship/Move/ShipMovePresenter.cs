using Global;
using Global.Base;
using UnityEngine;
using Utilities.Interfaces;

namespace Game.Entities.Ship.Move
{
    public class ShipMovePresenter : IPresenter
    {
        private readonly IGlobalEnvironment _environment;
        private readonly ShipMoveModel _model;

        private const float MOVE_FORWARD_VALUE = 7f;
        private const float TURN_SIDE_VALUE = 20f;
        
        public ShipMovePresenter(IGlobalEnvironment environment, ShipMoveModel model)
        {
            _environment = environment;
            _model = model;
        }
        
        public void Activate() => _model.OnUpdate += Update;

        public void Deactivate() => _model.OnUpdate -= Update;

        private void Update(float deltaTime) => Move(deltaTime);

        private void Move(float deltaTime)
        {
            var shipView = _environment.GameSceneView.GameView.CurrentShip;
            var direction = new Vector3(0,0,MOVE_FORWARD_VALUE)
            {
                x = _environment.InputModel.ShipTurnDirection switch
                {
                    >0 => TURN_SIDE_VALUE,
                    <0 => -TURN_SIDE_VALUE,
                    _ => 0f
                }
            };
            
            _model.UpdatePosition(shipView.Move(direction * _model.ShipSpeed));

            var shipPosition = CheckLimitsOverlap();

            shipView.ResetPosition(shipPosition);
            _model.UpdatePosition(shipPosition);
        }

        private Vector3 CheckLimitsOverlap()
        {
            var zoneLimits = _environment.GameModel.ZoneLimits;
            var shipPosition = _model.Position;
            var x = shipPosition.x;

            if (x > zoneLimits.RightSide)
            {
                x -= zoneLimits.RightSide * 2;
            }
            else if (x < zoneLimits.LeftSide)
            {
                x += Mathf.Abs(zoneLimits.LeftSide * 2);
            }

            shipPosition.x = x;
            
            return shipPosition;
        }
    }
}