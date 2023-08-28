using System;
using Global;
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
        
        public void Activate() => _environment.ShipModel.MoveModel.OnUpdate += UpdateDistance;

        public void Deactivate() => _environment.ShipModel.MoveModel.OnUpdate -= UpdateDistance;

        private void UpdateDistance(float deltaTime)
        {
            var shipPosition = _environment.GameModel.CurrentDimension switch
            {
                CameraDimensionsTypes.TwoD => (int)_environment.ShipModel.MoveModel.Position.y,
                CameraDimensionsTypes.ThreeD => (int)_environment.ShipModel.MoveModel.Position.z,
                _ => throw new ArgumentOutOfRangeException()
            };

            _environment.GameModel.UpdateDistance(shipPosition);
            _view.UpdateDistance(Mathf.Abs(shipPosition));
        }
    }
}