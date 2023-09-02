using Global;
using UnityEngine;
using Utilities;
using Utilities.Interfaces;

namespace Game.Entities.Ship.Move
{
    public class ShipMovePresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly ShipMoveModel _model;
        private bool _isPaused;

        private const float MOVE_FORWARD_VALUE = 7f;
        private const float TURN_SIDE_VALUE = 20f;
        
        public ShipMovePresenter(GlobalEnvironment environment, ShipMoveModel model)
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
            
            Move(deltaTime);
        }

        private void Move(float deltaTime)
        {
            var shipView = _environment.GameSceneView.GameView.CurrentShip;
            var zoneLimits = _environment.GameModel.ZoneLimits;
            var direction = new Vector3(0,0,MOVE_FORWARD_VALUE)
            {
                x = _environment.InputModel.ShipTurnDirection switch
                {
                    1.0f => TURN_SIDE_VALUE,
                    -1.0f => -TURN_SIDE_VALUE,
                    _ => 0f
                }
            };
            
            _model.UpdatePosition(shipView.Move(direction * _model.ShipSpeed));

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
            
            shipView.ResetPosition(shipPosition);
            _model.UpdatePosition(shipPosition);
        }
        
        private void ContinueActions() => _isPaused = false;

        private void PauseActions() => _isPaused = true;
    }
}