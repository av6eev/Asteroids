using Global.Dialogs.Shop.Card.Base;
using Utilities.Interfaces;

namespace Global.Dialogs.Shop.Card
{
    public class ShopCardDialogPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly ShopCardDialogModel _model;
        private readonly IShopCardDialogView _view;

        public ShopCardDialogPresenter(GlobalEnvironment environment, ShopCardDialogModel model, IShopCardDialogView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _view.InitializeButtonsSubscriptions();
            
            _view.OnNextSelected += ShowNextCard;
            _view.OnPreviousSelected += ShowPreviousCard;
            _view.OnBought += BuyShip;
            _view.OnSelected += SelectShip;
            
            _model.OnShow += Show;
            _model.OnHide += Hide;
            _model.OnPurchased += HandlePurchase;
        }

        public void Deactivate()
        {
            _view.OnNextSelected -= ShowNextCard;
            _view.OnPreviousSelected -= ShowPreviousCard;
            _view.OnBought -= BuyShip;
            _view.OnSelected -= SelectShip;

            _view.DisposeButtonsSubscriptions();
            
            _model.OnShow -= Show;
            _model.OnHide -= Hide;
            _model.OnPurchased -= HandlePurchase;
        }

        private void HandlePurchase()
        {
            _view.SwitchButtons(_model.IsPurchased);
            _view.ChangePriceText(_model.IsPurchased);
        }

        private void SelectShip()
        {
            _environment.GlobalUIModel.SetSelectedShip(_model.Id);
            _environment.DialogsModel.GetByType<ShopDialogModel>().Hide();
        }

        private void BuyShip() => _environment.DialogsModel.GetByType<ShopDialogModel>().BuyShip(_model.ShipSpecification);

        private void ShowPreviousCard() => _environment.DialogsModel.GetByType<ShopDialogModel>().ChangeActiveCard(-1);

        private void ShowNextCard() => _environment.DialogsModel.GetByType<ShopDialogModel>().ChangeActiveCard(1);

        private void Show()
        {
            _view.SwitchButtons(_model.IsPurchased);
            _view.ChangePriceText(_model.IsPurchased);
            
            _view.Show();
        }
        
        private void Hide() => _view.Hide();
    }
}