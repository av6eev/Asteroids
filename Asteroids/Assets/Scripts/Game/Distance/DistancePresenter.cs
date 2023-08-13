using Global;
using Utilities;

namespace Game.Distance
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
            var shipPosition = _environment.ShipModel.MoveModel.Position.z;
            
            _model.UpdateDistance(shipPosition);
            _view.UpdateDistance(shipPosition);
        }
    }
}