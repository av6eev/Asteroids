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
    public class ScenesManager
    {
        private GlobalEnvironment _environment;
        private AsyncOperation _asyncOperation;
        private IPresenter _presenter;

        public void LoadScene(ScenesNames sceneName, GlobalEnvironment environment)
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
                    _environment.GlobalView.MainCamera.gameObject.SetActive(false);
                    
                    _presenter = new GamePresenter(_environment, model, view);
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
            
            _environment.GlobalView.GlobalUIView.ChangeVisibility(true);
            _environment.GlobalView.EventSystem.enabled = true;
            _environment.GlobalView.MainCamera.gameObject.SetActive(true);
            
            _presenter = null;
        }
    }
}