using Game.Input;
using Game.Scene;
using Game.Ship;
using Game.Systems;
using UnityEngine;
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
            
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.ShipMovement);
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.CameraFollow);
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.Ship);
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.Input);
        }
        
        private void CreateShip()
        {
            var neededSpecification = _environment.Specifications.Ships[_environment.GlobalUIModel.SelectedShipId];
            var shipView = _view.GameView.InstantiateShip(neededSpecification.Prefab,new Vector3(0,0,0));

            _environment.ShipModel = new ShipModel(neededSpecification);
            _presenters.Add(new ShipPresenter(_environment, _environment.ShipModel, shipView));
            
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.ShipMovement, new ShipMovementUpdater());
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.CameraFollow, new CameraFollowUpdater());
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.Ship, new ShipUpdater());
        }
        
        private void CreateNecessaryData()
        {
            _environment.InputModel = new InputModel();
            
            _presenters.Add(new InputPresenter(_environment, _environment.InputModel, _view.InputView));
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.Input, new InputUpdater());
        }
    }
}