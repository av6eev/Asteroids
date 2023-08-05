using System.Linq;
using Global.Dialogs.Shop.Card;
using Utilities;

namespace Global.Dialogs.Shop
{
    public class ShopDialogPresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly ShopDialogModel _model;
        private readonly ShopDialogView _view;

        private readonly PresentersEngine _cardsPresenters = new();

        public ShopDialogPresenter(GameEnvironment environment, ShopDialogModel model, ShopDialogView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _view.ExitButton.onClick.AddListener(Hide);
            
            _model.OnShow += Show;
            _model.OnHide += Hide;
        }

        public void Deactivate()
        {
            _cardsPresenters.Deactivate();
            _cardsPresenters.Clear();
            
            _view.ExitButton.onClick.RemoveListener(Hide);
            
            _model.OnShow -= Show;
            _model.OnHide -= Hide;
        }

        private void Show()
        {
            foreach (var specification in _model.ShipSpecifications)
            {
                var model = new ShopCardDialogModel(specification.Value);
                var presenter = new ShopCardDialogPresenter(_environment, model, _view.InstantiateCard(specification.Value));
                
                _model.Cards.Add(model);
                _cardsPresenters.Add(presenter);
            }
            
            _cardsPresenters.Activate();
            _model.Cards.First().Show();
            
            _view.ChangeVisibility(true);
        }

        private void Hide()
        {
            _cardsPresenters.Deactivate();
            _cardsPresenters.Clear();
            
            _view.DestroyCards();
            _view.ChangeVisibility(false);
            
            _environment.GlobalView.GlobalUIView.MainMenuRoot.SetActive(true);
        }
    }
}