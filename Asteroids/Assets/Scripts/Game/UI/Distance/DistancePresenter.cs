using Game.UI.Distance.Base;
using Global;
using UnityEngine;
using Utilities.Interfaces;

namespace Game.UI.Distance
{
    public class DistancePresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly BaseDistanceView _view;

        public DistancePresenter(GlobalEnvironment environment, BaseDistanceView view)
        {
            _environment = environment;
            _view = view;
        }
        
        public void Activate() => _environment.ShipModel.MoveModel.OnUpdate += UpdateDistance;

        public void Deactivate() => _environment.ShipModel.MoveModel.OnUpdate -= UpdateDistance;

        private void UpdateDistance(float deltaTime)
        {
            var shipPosition = (int)_environment.ShipModel.GetMainCoordinate();

            _environment.GameModel.UpdateDistance(shipPosition);
            _view.UpdateDistance(Mathf.Abs(shipPosition));
        }
    }
}