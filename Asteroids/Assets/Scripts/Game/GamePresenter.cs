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
            _model.ZoneLimits = CreateGameZoneLimits();
            CreateShip();
            CreateNecessaryData();
            
            _presenters.Activate();
        }

        public void Deactivate()
        {
            _presenters.Deactivate();
            _presenters.Clear();
            
            _environment.FixedSystemsEngine.Remove(SystemsTypes.ShipMovement);
            _environment.FixedSystemsEngine.Remove(SystemsTypes.CameraFollow);
        }
        
        private void CreateShip()
        {
            var neededSpecification = _environment.Specifications.Ships[_environment.GlobalUIModel.SelectedShipId];
            var shipView = _view.GameView.InstantiateShip(neededSpecification.Prefab,new Vector3(0,0,0));

            _environment.ShipModel = new ShipModel(neededSpecification);
            _presenters.Add(new ShipPresenter(_environment, _environment.ShipModel, shipView));
            
            _environment.FixedSystemsEngine.Add(SystemsTypes.ShipMovement, new ShipMovementSystem());
            _environment.FixedSystemsEngine.Add(SystemsTypes.CameraFollow, new CameraFollowSystem());
        }
        
        private void CreateNecessaryData()
        {
            _environment.InputModel = new InputModel();
            
            _presenters.Add(new InputPresenter(_environment, _environment.InputModel, _view.InputView));
        }
        
        private GameZoneLimits CreateGameZoneLimits()
        {
            var limits = new GameZoneLimits();
            
            //TODO: continue
            
            return limits;
        }
    }
}