﻿using Game.UI.Difficulty;
using Game.UI.Distance;
using Game.UI.EndScreen;
using Game.UI.Health;
using Game.UI.Money;
using Game.UI.Score;
using Global;
using UnityEngine;
using Utilities.Engines;
using Utilities.Interfaces;

namespace Game.UI
{
    public class GameUIPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly GameUIView _view;

        private readonly PresentersEngine _presenters = new();
        private int _cameraChangeCounter;
        
        public GameUIPresenter(GlobalEnvironment environment, GameUIView view)
        {
            _environment = environment;
            _view = view;
        }
        
        public void Activate()
        {
            _view.EndScreenView.ChangeVisibility(false);
            
            CreateNecessaryData();
            
            _view.ChangeCameraButton.onClick.AddListener(ChangeCameraView);

            _environment.GameModel.OnEnded += HideElements;
        }

        public void Deactivate()
        {
            _presenters.Deactivate();
            _presenters.Clear();
            
            _view.ChangeCameraButton.onClick.RemoveListener(ChangeCameraView);
            
            _environment.GameModel.OnEnded -= HideElements;
            
            Debug.Log(nameof(GameUIPresenter) + " deactivated!");
        }

        private void HideElements() => _view.HideElementsAfterEnd();

        private void ChangeCameraView()
        {
            _cameraChangeCounter++;
            
            _environment.GameModel.ChangeDimension(_cameraChangeCounter % 2);
        }

        private void CreateNecessaryData()
        {
            _presenters.Add(new ScorePresenter(_environment, _view.ScoreView));
            _presenters.Add(new DistancePresenter(_environment, _view.DistanceView));
            _presenters.Add(new MoneyPresenter(_environment, _view.MoneyView));
            _presenters.Add(new DifficultyPresenter(_environment, _view.DifficultyView));
            _presenters.Add(new HealthPresenter(_environment, _view.HealthView));
            _presenters.Add(new EndScreenPresenter(_environment, _view.EndScreenView));

            _presenters.Activate();
        }
    }
}