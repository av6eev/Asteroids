using Game.Asteroids;
using Game.Input;
using Game.Scene;
using Game.Ship;
using Game.Systems;
using Utilities;

namespace Game
{
    public class GamePresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly GameModel _model;
        private readonly GameSceneView _view;
        
        private readonly PresentersEngine _presenters = new();
        
        public GamePresenter(GameEnvironment environment, GameModel model, GameSceneView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            CreateShip();
            CreateNecessaryData();
            
            _presenters.Activate();
        }

        public void Deactivate()
        {
            _presenters.Deactivate();
            _presenters.Clear();
            
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.CameraFollow);
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.Input);
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.Asteroids);
        }
        
        private void CreateShip()
        {
            var neededSpecification = _environment.Specifications.Ships[_environment.GlobalUIModel.SelectedShipId];
            var shipView = _view.GameView.InstantiateShip(neededSpecification.Prefab);

            _environment.ShipModel = new ShipModel(neededSpecification);
            _presenters.Add(new ShipPresenter(_environment, _environment.ShipModel, shipView));
        }
        
        private void CreateNecessaryData()
        {
            _environment.InputModel = new InputModel();
            _environment.AsteroidsModel = new AsteroidsModel(_environment.Specifications.Asteroids);
            
            _presenters.Add(new InputPresenter(_environment, _environment.InputModel, _view.InputView));
            _presenters.Add(new AsteroidsPresenter(_environment, _environment.AsteroidsModel));
            
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.CameraFollow, new CameraFollowUpdater());
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.Input, new InputUpdater());
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.Asteroids, new AsteroidsUpdater());
        }
    }
}