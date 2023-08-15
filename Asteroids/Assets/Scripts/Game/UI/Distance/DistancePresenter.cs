using Global;
using UnityEngine;
using Utilities;

namespace Game.UI.Distance
{
    public class DistancePresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly DistanceModel _model;
        private readonly DistanceView _view;

        public DistancePresenter(GlobalEnvironment environment, DistanceModel model, DistanceView view)
        {
            _environment = environment;
            _model = model;
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

            _model.UpdateDistance(shipPosition);
            _view.UpdateElement(Mathf.Abs(shipPosition));
            
            if (_model.CurrentDistance != 0 && _model.CurrentDistance % 400 == 0)
            {
                _environment.PlayerModel.IncreaseMoney(2);
            }
        }
    }
}