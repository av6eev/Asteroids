using System.Linq;
using Game.CamerasUpdaters;
using Game.Entities.Asteroids;
using Game.Entities.Ship;
using Game.Entities.Ship.Base;
using Game.Input;
using Game.Scene;
using Game.UI;
using Global;
using Global.Dialogs.History;
using Global.Pulls.Base;
using Global.Requirements.DistancePassed.First;
using Global.Requirements.DistancePassed.Second;
using Global.Requirements.DistancePassed.Third;
using UnityEngine;
using Utilities;

namespace Game
{
    public class GamePresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly GameModel _model;
        private readonly GameSceneView _view;
        
        private readonly PresentersEngine _presenters = new();
        private readonly PresentersEngine _requirementsPresenters = new();
        
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

            _model.OnClosed += Close;
            _model.OnEnded += Save;
            _model.OnDimensionChanged += ChangeActiveDimension;
        }

        public void Deactivate()
        {
            _presenters.Deactivate();
            _presenters.Clear();
            
            _requirementsPresenters.Deactivate();
            _requirementsPresenters.Clear();
            
            _model.OnClosed -= Close;
            _model.OnEnded -= Save;
            _model.OnDimensionChanged -= ChangeActiveDimension;
        }

        private void ChangeActiveDimension()
        {
            var shipModel = _environment.ShipModel;
            shipModel.PauseActions();
            
            BaseShipView neededShipPrefab = null;

            switch (_model.CurrentDimension)
            {
                case CameraDimensionsTypes.TwoD:
                    neededShipPrefab = shipModel.Specification.Prefab2D;

                    _environment.LateUpdatersEngine.Remove(UpdatersTypes.ThirdPersonCameraFollow);
                    _environment.LateUpdatersEngine.Add(UpdatersTypes.TopDownCameraFollow, new TopDownCameraFollowUpdater(new Vector3(0f, 30f, -1f), _view.TopDownCamera));

                    _view.SwitchCamera(CameraDimensionsTypes.TwoD);
                    break;
                case CameraDimensionsTypes.ThreeD:
                    neededShipPrefab = shipModel.Specification.Prefab3D;
                    
                    _environment.LateUpdatersEngine.Remove(UpdatersTypes.TopDownCameraFollow);
                    _environment.LateUpdatersEngine.Add(UpdatersTypes.ThirdPersonCameraFollow, new ThirdPersonCameraFollowUpdater(new Vector3(0f, 42f, -55f), _view.ThirdPersonCamera));
                    
                    _view.SwitchCamera(CameraDimensionsTypes.ThreeD);
                    break;
            }

            _view.GameView.ChangeActivePulls(_model.CurrentDimension);
            
            shipModel.ChangeView(_view.GameView.RedrawShip(neededShipPrefab, shipModel.MoveModel.RecalculatePosition(_model.CurrentDimension)));
            shipModel.ContinueActions();
        }

        private void CreateShip()
        {
            var neededSpecification = _environment.Specifications.Ships.Values.First(ship => ship.Id == _environment.GlobalUIModel.SelectedShipId);
            var shipView = _view.GameView.InstantiateShip(neededSpecification.Prefab2D);

            _environment.ShipModel = new ShipModel(neededSpecification);
            _presenters.Add(new ShipPresenter(_environment, _environment.ShipModel, shipView));
        }

        private void DestroyShip() => _view.GameView.DestroyShip();

        private void Close()
        {
            _environment.ScenesManager.UnloadScene(ScenesNames.GameScene);            
            _view.GameUIView.ChangeVisibility(false);
        }

        private void Save()
        {
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
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.TopDownCameraFollow, new TopDownCameraFollowUpdater(new Vector3(0f, 30f, -1f), _view.TopDownCamera));
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
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.TopDownCameraFollow);
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.ThirdPersonCameraFollow);
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.Asteroids);

            DestroyShip();
            _view.GameView.DestroyPulls();
        }
    }
}