using Global.Dialogs.Shop;
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
            _view.MainMenuRoot.SetActive(true);
            _view.ShopMenuRoot.SetActive(false);
            
            _view.PlayButton.onClick.AddListener(StartGame);
            _view.ShopButton.onClick.AddListener(OpenShopMenu);
            // _view.HistoryButton.onClick.AddListener(StartGame);
        }
        
        public void Deactivate()
        {
            _view.PlayButton.onClick.RemoveListener(StartGame);
            _view.ShopButton.onClick.RemoveListener(OpenShopMenu);
            // _view.HistoryButton.onClick.RemoveListener(StartGame);
        }

        private void OpenShopMenu()
        {
            _view.MainMenuRoot.SetActive(false);
            
            _environment.DialogsModel.GetByType<ShopDialogModel>().Show();
        }

        private void StartGame()
        {
            _view.ChangeVisibility(false);
            _environment.ScenesManager.LoadScene(ScenesNames.GameScene, _environment);
        }
    }
}