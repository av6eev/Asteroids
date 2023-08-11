﻿using UnityEngine;
using Utilities;

namespace Game.Ship.Move
{
    public class ShipMovePresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly ShipMoveModel _model;

        private const float MOVE_FORWARD_VALUE = 10f;
        private const float TURN_SIDE_VALUE = 10f;
        
        public ShipMovePresenter(GameEnvironment environment, ShipMoveModel model)
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
            Move(deltaTime);
        }
        
        private void Move(float deltaTime)
        {
            var shipView = _environment.GameSceneView.GameView.CurrentShip;
            var zoneLimits = _environment.GameSceneView.GameView.ZoneLimits;
            var direction = new Vector3(0,0,MOVE_FORWARD_VALUE)
            {
                x = _environment.InputModel.ShipRotateDirection switch
                {
                    1.0f => TURN_SIDE_VALUE,
                    -1.0f => -TURN_SIDE_VALUE,
                    _ => 0f
                }
            };

            direction *= _model.ShipSpeed * deltaTime;
            _model.Position = shipView.Move(direction);

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
            _model.Position = shipPosition;
        }
    }
}