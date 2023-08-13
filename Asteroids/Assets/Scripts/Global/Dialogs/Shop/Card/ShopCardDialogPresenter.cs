using Utilities;

namespace Global.Dialogs.Shop.Card
{
    public class ShopCardDialogPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly ShopCardDialogModel _model;
        private readonly ShopCardDialogView _view;

        public ShopCardDialogPresenter(GlobalEnvironment environment, ShopCardDialogModel model, ShopCardDialogView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _view.NextCardButton.onClick.AddListener(ShowNextCard);
            _view.PreviousCardButton.onClick.AddListener(ShowPreviousCard);
            
            _model.OnShow += Show;
            _model.OnHide += Hide;
        }

        public void Deactivate()
        {
            _view.NextCardButton.onClick.RemoveListener(ShowNextCard);
            _view.PreviousCardButton.onClick.RemoveListener(ShowPreviousCard);

            _model.OnShow -= Show;
            _model.OnHide -= Hide;
        }

        private void ShowPreviousCard()
        {
            _environment.DialogsModel.GetByType<ShopDialogModel>().ChangeActiveCard(-1);
        }

        private void ShowNextCard()
        {
            _environment.DialogsModel.GetByType<ShopDialogModel>().ChangeActiveCard(1);
        }

        private void Show()
        {
            _view.ChangeVisibility(true);
        }
        
        private void Hide()
        {
            _view.ChangeVisibility(false);
        }
    }
}