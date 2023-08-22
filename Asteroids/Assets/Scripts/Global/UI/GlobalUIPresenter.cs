using Global.Dialogs.History;
using Global.Dialogs.Shop;
using UnityEngine;
using Utilities;

namespace Global.UI
{
    public class GlobalUIPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly GlobalUIView _view;

        public GlobalUIPresenter(GlobalEnvironment environment, GlobalUIModel model, GlobalUIView view)
        {
            _environment = environment;
            _view = view;
        }
        
        public void Activate()
        {
            _view.MainMenuRoot.SetActive(true);
            
            _view.PlayButton.onClick.AddListener(StartGame);
            _view.ShopButton.onClick.AddListener(OpenShopMenu);
            _view.HistoryButton.onClick.AddListener(OpenHistoryMenu);
            _view.ExitButton.onClick.AddListener(CloseGame);
        }
        
        public void Deactivate()
        {
            _view.PlayButton.onClick.RemoveListener(StartGame);
            _view.ShopButton.onClick.RemoveListener(OpenShopMenu);
            _view.HistoryButton.onClick.RemoveListener(OpenHistoryMenu);
            _view.ExitButton.onClick.RemoveListener(CloseGame);
        }

        private void OpenShopMenu()
        {
            HideMenuAndTitle();
            
            _environment.DialogsModel.GetByType<ShopDialogModel>().Show();
        }

        private void OpenHistoryMenu()
        {
            HideMenuAndTitle();
            
            _environment.DialogsModel.GetByType<HistoryDialogModel>().Show();
        }

        private void StartGame()
        {
            _view.ChangeVisibility(false);
            _environment.ScenesManager.LoadScene(ScenesNames.GameScene, _environment);
        }

        private void HideMenuAndTitle()
        {
            _view.MainMenuRoot.SetActive(false);
            _view.Title.SetActive(false);
        }

        private void CloseGame() => Application.Quit();
    }
}