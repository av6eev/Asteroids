using Utilities;

namespace Global.UI
{
    public class GlobalUIPresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly GlobalUIView _view;

        public GlobalUIPresenter(GameEnvironment environment, GlobalUIModel model, GlobalUIView view)
        {
            _environment = environment;
            _view = view;
        }
        
        public void Activate()
        {
            _view.PlayButton.onClick.AddListener(StartGame);
        }
        
        public void Deactivate()
        {
            _view.PlayButton.onClick.RemoveListener(StartGame);
        }
        
        private void StartGame()
        {
            _view.ChangeVisibility(false);
            _environment.ScenesManager.LoadScene(ScenesNames.GameScene, _environment);
        }
    }
}