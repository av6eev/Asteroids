using Global.Dialogs.Shop.Base;
using Global.Dialogs.Shop.Card;
using Utilities.Engines;
using Utilities.Interfaces;

namespace Global.Dialogs.Shop
{
    public class ShopDialogPresenter : IPresenter
    {
        private readonly IGlobalEnvironment _environment;
        private readonly IShopDialogModel _model;
        private readonly IShopDialogView _view;

        private readonly PresentersEngine _cardsPresenters = new();

        public ShopDialogPresenter(IGlobalEnvironment environment, IShopDialogModel model, IShopDialogView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _view.Hide();
            _view.InitializeButtonsSubscriptions();
            
            _view.OnExitClicked += Hide;
            
            _model.OnShow += Show;
            _model.OnHide += Hide;
            _model.OnCardChange += ChangeActiveCard;
            _model.OnRedraw += RedrawCard;

            _environment.PlayerModel.OnMoneyUpdated += UpdatePlayerBalance;
        }

        public void Deactivate()
        {
            _cardsPresenters.Deactivate();
            _cardsPresenters.Clear();
            
            _view.OnExitClicked -= Hide;
            _view.DisposeButtonsSubscriptions();
            
            _model.OnShow -= Show;
            _model.OnHide -= Hide;
            _model.OnCardChange -= ChangeActiveCard;
            _model.OnRedraw -= RedrawCard;
            
            _environment.PlayerModel.OnMoneyUpdated -= UpdatePlayerBalance;
        }

        private void RedrawCard(int shipId)
        {
            _view.UpdateBalanceText(_environment.PlayerModel.Money);
            _model.Cards.Find(card => card.Id == shipId).SetPurchased(true);
        }

        private void UpdatePlayerBalance(int money) => _view.UpdateBalanceText(money);

        private void ChangeActiveCard(int changeDirection)
        {
            var activeCard = _model.ActiveCard;
            var nextCard = _model.Cards.Find(card => card.Id == activeCard.Id + changeDirection);
            
            if (nextCard != null)
            {
                activeCard.Hide();
                nextCard.Show();    
            }
        }

        private void Show()
        {
            foreach (var specification in _environment.Specifications.Ships)
            {
                if (!_environment.GlobalUIModel.AvailableShips.TryGetValue(specification.Key, out var isPurchased)) continue;
                
                var model = new ShopCardDialogModel(specification.Value.Type, specification.Value.Id, isPurchased);
                var presenter = new ShopCardDialogPresenter(_environment, model, _view.InstantiateCard(specification.Value));
                
                _model.Cards.Add(model);
                _cardsPresenters.Add(presenter);
            }
            
            _cardsPresenters.Activate();
            _model.Cards.Find(card => card.Id == _environment.GlobalUIModel.SelectedShipId).Show();
            _view.Show();
        }

        private void Hide()
        {
            _cardsPresenters.Deactivate();
            _cardsPresenters.Clear();
            
            _model.Cards.Clear();
            
            _view.DestroyCards();
            _view.Hide();
            
            _environment.GlobalSceneView.GlobalUIView.ShowDecorationElements();
        }
    }
}