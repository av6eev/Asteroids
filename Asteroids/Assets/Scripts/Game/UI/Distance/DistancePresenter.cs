﻿using Global;
using UnityEngine;
using Utilities;

namespace Game.UI.Distance
{
    public class DistancePresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly DistanceView _view;

        public DistancePresenter(GlobalEnvironment environment, DistanceView view)
        {
            _environment = environment;
            _view = view;
        }
        
        public void Activate()
        {
            _environment.ShipModel.MoveModel.OnUpdate += UpdateDistance;
        }

        public void Deactivate()
        {
            _environment.ShipModel.MoveModel.OnUpdate -= UpdateDistance;
        }

        private void UpdateDistance(float deltaTime)
        {
            var shipPosition = (int)_environment.ShipModel.MoveModel.Position.z;
            var gameModel = _environment.GameModel;
            
            gameModel.UpdateDistance(shipPosition);
            _view.UpdateDistance(Mathf.Abs(shipPosition));
        }
    }
}