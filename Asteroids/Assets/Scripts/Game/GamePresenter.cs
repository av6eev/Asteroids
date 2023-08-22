using System.Linq;
using Game.Asteroids;
using Game.CameraUpdater;
using Game.Input;
using Game.Scene;
using Game.Ship;
using Game.UI;
using Global;
using Global.Dialogs.History;
using Global.Pulls.Base;
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
        }

        public void Deactivate()
        {
            _presenters.Deactivate();
            _presenters.Clear();
            
            _model.OnClosed -= Close;
            _model.OnEnded -= Save;
            
            Debug.Log(nameof(GamePresenter) + " deactivated!");
        }

        private void CreateShip()
        {
            var neededSpecification = _environment.Specifications.Ships.Values.First(ship => ship.Id == _environment.GlobalUIModel.SelectedShipId);
            var shipView = _view.GameView.InstantiateShip(neededSpecification.Prefab);

            _environment.ShipModel = new ShipModel(neededSpecification);
            
            _presenters.Add(new ShipPresenter(_environment, _environment.ShipModel, shipView));
        }

        private void DestroyShip() => _view.GameView.DestroyShip();

        private void CreateNecessaryData()
        {
            _environment.InputModel = new InputModel();
            _environment.AsteroidsModel = new AsteroidsModel(_environment.Specifications.Asteroids);
            _environment.PullsData = new PullsData();

            _presenters.Add(new InputPresenter(_environment, _environment.InputModel, _view.InputView));
            _presenters.Add(new AsteroidsPresenter(_environment, _environment.AsteroidsModel));
            _presenters.Add(new GameUIPresenter(_environment, _view.GameUIView));

            _presenters.Activate();
            
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.CameraFollow, new CameraFollowUpdater());
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.Input, new InputUpdater());
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.Asteroids, new AsteroidsUpdater());
        }

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
            
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.CameraFollow);
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.Input);
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.Asteroids);

            DestroyShip();
            _view.GameView.DestroyPulls();
        }
    }
}