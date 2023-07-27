using Game.Scene;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utilities
{
    public class ScenesManager
    {
        private GameEnvironment _environment;
        private AsyncOperation _asyncOperation;
        private IPresenter _presenter;

        public ScenesManager(GameEnvironment environment)
        {
            _environment = environment;
        }

        public void LoadScene(ScenesNames sceneName, GameEnvironment environment)
        {
            _environment = environment;
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
                    break;
            }
        }

        public void UnloadScene(ScenesNames sceneName)
        {
            _asyncOperation = SceneManager.UnloadSceneAsync($"{sceneName}");
            _asyncOperation.completed += OnUnloadCompleted;
        }

        private void OnUnloadCompleted(AsyncOperation operation)
        {
            _presenter.Deactivate();
            _presenter = null;
        }
    }
}