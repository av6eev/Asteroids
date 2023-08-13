using Game.Asteroids;
using Game.Input;
using Game.Scene;
using Game.Ship;
using Game.Systems;
using Game.UI;
using Global.Pulls.Base;
using UnityEngine;
using UnityEngine.EventSystems;
using Utilities;

namespace Game
{
    public class GamePresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly GameModel _model;
        private readonly GameSceneView _view;
        
        private readonly PresentersEngine _presenters = new();
        
        public GamePresenter(GlobalEnvironment environment, GameModel model, GameSceneView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            CreateShip();
            CreateNecessaryData();

            _model.OnGameEnded += EndGame;
        }

        public void Deactivate()
        {
            _environment.GlobalView.MainCamera.enabled = true;
            
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.CameraFollow);
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.Input);
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.Asteroids);
            
            _presenters.Deactivate();
            _presenters.Clear();
            
            _model.OnGameEnded -= EndGame;
            
            Debug.Log(nameof(GamePresenter) + " deactivated!");
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
            _environment.PullsData = new PullsData();
            
            _presenters.Add(new GameUIPresenter(_environment, new GameUIModel(), _view.GameUIView));
            _presenters.Add(new InputPresenter(_environment, _environment.InputModel, _view.InputView));
            _presenters.Add(new AsteroidsPresenter(_environment, _environment.AsteroidsModel));
            
            _presenters.Activate();
            
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.CameraFollow, new CameraFollowUpdater());
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.Input, new InputUpdater());
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.Asteroids, new AsteroidsUpdater());
        }

        private void EndGame()
        {
            Deactivate();
            
            _environment.ScenesManager.UnloadScene(ScenesNames.GameScene);            
            _environment.GlobalView.GlobalUIView.ChangeVisibility(true);
        }
    }
}