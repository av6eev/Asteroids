using Utilities;

namespace Game.Ship
{
    public class ShipPresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly ShipModel _model;
        private readonly ShipView _view;

        public ShipPresenter(GameEnvironment environment, ShipModel model, ShipView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            CreateShotsPull();
        }
        
        public void Deactivate()
        {
        }
        
        private void CreateShotsPull()
        {
            var shotsPull = _environment.GameSceneView.GameView.ShotsPullView;
            
            shotsPull.ElementPrefab = _model.Specification.ShotPrefab;
            shotsPull.Count = _model.Specification.Count;
            
            _environment.PullsData.ShotsPull.CreatePull(shotsPull);   
        }
    }
}