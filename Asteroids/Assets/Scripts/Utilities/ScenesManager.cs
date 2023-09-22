using Game;
using Game.Scene;
using Global;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Utilities.BaseClasses;
using Utilities.Enums;
using Utilities.Interfaces;

namespace Utilities
{
    public class ScenesManager : IScenesManager
    {
        private IGlobalEnvironment _environment;
        private AsyncOperation _asyncOperation;
        private IPresenter _presenter;

        public void LoadScene(ScenesNames sceneName, IGlobalEnvironment environment)
        {
            _environment = environment;
            
            EventSystem.current.enabled = false;
            
            _asyncOperation = SceneManager.LoadSceneAsync((int)sceneName, LoadSceneMode.Additive);
            _asyncOperation.completed += OnLoadCompleted;
        }

        private void OnLoadCompleted(AsyncOperation operation)
        {
            _asyncOperation.completed -= OnLoadCompleted;

            var gameSceneView = GameObject.Find("scene_view").GetComponent<BaseSceneView>();
            
            switch (gameSceneView)
            {
                case GameSceneView view:
                    
                    var model = new GameModel();

                    _environment.GameModel = model;
                    _environment.GameSceneView = view;
                    _environment.GlobalSceneView.DisableCamera();
                    
                    _presenter = new GamePresenter(_environment, model, view.GameView);
                    break;
            }
            
            _presenter.Activate();
        }

        public void UnloadScene(ScenesNames sceneName)
        {
            _asyncOperation = SceneManager.UnloadSceneAsync($"{sceneName}");
            _asyncOperation.completed += OnUnloadCompleted;
        }

        private void OnUnloadCompleted(AsyncOperation operation)
        {
            if (_presenter is not GamePresenter)
            {
                _presenter.Deactivate();
            }
            
            _environment.GlobalSceneView.GlobalUIView.Show();
            _environment.GlobalSceneView.EnableEventSystem();
            _environment.GlobalSceneView.EnableCamera();
            
            _presenter = null;
        }
    }
}