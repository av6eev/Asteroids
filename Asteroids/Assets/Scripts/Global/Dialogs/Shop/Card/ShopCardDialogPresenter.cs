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
            _view.BuyButton.onClick.AddListener(BuyShip);
            _view.SelectButton.onClick.AddListener(SelectShip);
            
            _model.OnShow += Show;
            _model.OnHide += Hide;
            _model.OnButtonsSwitch += SwitchButtons;
        }

        public void Deactivate()
        {
            _view.NextCardButton.onClick.RemoveListener(ShowNextCard);
            _view.PreviousCardButton.onClick.RemoveListener(ShowPreviousCard);
            _view.BuyButton.onClick.RemoveListener(BuyShip);
            _view.SelectButton.onClick.RemoveListener(SelectShip);

            _model.OnShow -= Show;
            _model.OnHide -= Hide;
            _model.OnButtonsSwitch -= SwitchButtons;
        }

        private void SwitchButtons()
        {
            _view.SwitchButtons();
        }

        private void SelectShip()
        {
            _environment.GlobalUIModel.SelectedShipId = _model.Id;
            _environment.DialogsModel.GetByType<ShopDialogModel>().Hide();
        }

        private void BuyShip()
        {
            _environment.DialogsModel.GetByType<ShopDialogModel>().BuyShip(_model.ShipSpecification.Type, _model.ShipSpecification.Price);
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
            if (_model.IsPurchased)
            {
                _view.SwitchButtons();
                _view.ChangePriceText();
            }
            
            _view.ChangeVisibility(true);
        }
        
        private void Hide()
        {
            _view.ChangeVisibility(false);
        }
    }
}