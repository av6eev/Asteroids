using System.Linq;
using Game.CamerasUpdaters;
using Game.CamerasUpdaters.Base;
using Game.Entities.Asteroids;
using Game.Entities.Ship;
using Game.Factories.Ship;
using Game.Factories.Ship.Base;
using Game.Input;
using Game.Scene;
using Game.UI;
using Global;
using Global.Dialogs.History;
using Global.Pulls.Base;
using Global.Requirements.DistancePassed.First;
using Global.Requirements.DistancePassed.Second;
using Global.Requirements.DistancePassed.Third;
using Global.Sound;
using UnityEngine;
using Utilities.Engines;
using Utilities.Enums;
using Utilities.Interfaces;

namespace Game
{
    public class GamePresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly IGameModel _model;
        private readonly GameSceneView _view;
        
        private readonly PresentersEngine _presenters = new();
        private readonly PresentersEngine _requirementsPresenters = new();
        private ShipPresenter _currentShipPresenter;

        private BaseShipModelFactory _shipModelFactory = new BaseShipModel2DFactory();
        
        public GamePresenter(GlobalEnvironment environment, IGameModel model, GameSceneView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            CreateShip();
            CreateNecessaryData();

            _model.OnClosed += Close;
            _model.OnEnded += Save;
            _model.OnDimensionChanged += ChangeSetup;
        }

        public void Deactivate()
        {
            _presenters.Deactivate();
            _presenters.Clear();
            
            _requirementsPresenters.Deactivate();
            _requirementsPresenters.Clear();
            
            _model.OnClosed -= Close;
            _model.OnEnded -= Save;
            _model.OnDimensionChanged -= ChangeSetup;
        }

        private void ChangeSetup()
        {
            BaseCameraFollowUpdater cameraFollowUpdater = null;
            
            switch (_model.CurrentDimension)
            {
                case CameraDimensionsTypes.TwoD:
                    _shipModelFactory = new BaseShipModel2DFactory();
                    cameraFollowUpdater = new TopDownCameraFollowUpdater(new Vector3(0f, 30f, -1f), _view.TopDownCamera);
                    break;
                case CameraDimensionsTypes.ThreeD:
                    _shipModelFactory = new BaseShipModel3DFactory();
                    cameraFollowUpdater = new ThirdPersonCameraFollowUpdater(new Vector3(0f, 42f, -55f), _view.ThirdPersonCamera);
                    break;
            }
            
            _environment.LateUpdatersEngine.Set(UpdatersTypes.CameraFollow, cameraFollowUpdater);

            var shipModel = _shipModelFactory.TryCreate(_environment.ShipModel);
            var newPosition = shipModel.GetPosition();
            
            shipModel.MoveModel.UpdatePosition(newPosition);
            
            _view.SwitchCamera(_model.CurrentDimension);
            _view.GameView.ChangeActivePulls(_model.CurrentDimension);

            _currentShipPresenter.Deactivate();
            _currentShipPresenter = new ShipPresenter(_environment, shipModel, _view.GameView.RedrawShip(shipModel.GetViewInSpecification(), newPosition));
            _currentShipPresenter.Activate();

            _environment.ShipModel = shipModel;
        }

        private void CreateShip()
        {
            var neededSpecification = _environment.Specifications.Ships.Values.First(ship => ship.Id == _environment.GlobalUIModel.SelectedShipId);
            var shipView = _view.GameView.InstantiateShip(neededSpecification.Prefab2D);
            
            _environment.ShipModel = _shipModelFactory.TryCreate(neededSpecification);
            _currentShipPresenter = new ShipPresenter(_environment, _environment.ShipModel, shipView); 
            
            _presenters.Add(_currentShipPresenter);
            _model.UpdateLives(_environment.ShipModel.CurrentHealth);
        }

        private void Close()
        {
            _environment.ScenesManager.UnloadScene(ScenesNames.GameScene);            
            _view.GameUIView.ChangeVisibility(false);
        }

        private void Save()
        {
            _environment.SoundManager.Reset();
            _view.GameUIView.HideElementsAfterEnd();
            
            _environment.DialogsModel.GetByType<HistoryDialogModel>().AddScore(_model.CurrentScore);
            _environment.SaveModel.Save();
            
            DeactivateUnnecessaryData();
        }

        private void CreateNecessaryData()
        {
            _environment.InputModel = new InputModel();
            _environment.AsteroidsModel = new AsteroidsModel(_environment.Specifications.Asteroids);
            _environment.PullsData = new PullsData();

            _presenters.Add(new InputPresenter(_environment, _environment.InputModel, _view.InputView));
            _presenters.Add(new AsteroidsPresenter(_environment, _environment.AsteroidsModel));
            _presenters.Add(new GameUIPresenter(_environment, _view.GameUIView));

            _presenters.Activate();

            _environment.UpdatersEngine.Add(UpdatersTypes.Input, new InputUpdater());
            _environment.LateUpdatersEngine.Add(UpdatersTypes.CameraFollow, new TopDownCameraFollowUpdater(new Vector3(0f, 30f, -1f), _view.TopDownCamera));
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.Asteroids, new AsteroidsUpdater());

            foreach (var requirement in _environment.Specifications.Requirements)
            {
                switch (requirement.Value)
                {
                    case FirstDistancePassedRequirement:
                        _requirementsPresenters.Add(new FirstDistancePassedRequirementPresenter(_environment, requirement.Value));
                        break;
                    case SecondDistancePassedRequirement:
                        _requirementsPresenters.Add(new SecondDistancePassedRequirementPresenter(_environment, requirement.Value));
                        break;
                    case ThirdDistancePassedRequirement:
                        _requirementsPresenters.Add(new ThirdDistancePassedRequirementPresenter(_environment, requirement.Value));
                        break;
                }
            }
            
            _requirementsPresenters.Activate();
            
            _environment.SoundManager.Play(SoundsTypes.Theme);
        }

        private void DeactivateUnnecessaryData()
        {
            var removedPresenters = new PresentersEngine();
            
            foreach (var presenter in _presenters.GetAll())
            {
                switch (presenter)
                {
                    case GameUIPresenter:
                        continue;
                }
                
                removedPresenters.Add(presenter);
            }
            
            foreach (var presenter in removedPresenters.GetAll())
            {
                _presenters.Remove(presenter);
            }
            
            removedPresenters.Clear();

            _environment.UpdatersEngine.Remove(UpdatersTypes.Input);
            _environment.LateUpdatersEngine.Remove(UpdatersTypes.CameraFollow);
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.Asteroids);

            _view.GameView.DestroyShip();
            _view.GameView.DestroyPulls();
        }
    }
}