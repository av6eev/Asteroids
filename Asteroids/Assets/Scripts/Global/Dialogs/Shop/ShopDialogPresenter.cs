using System.Linq;
using Global.Dialogs.Shop.Card;
using UnityEngine;
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
            _view.ChangeVisibility(false);
            _view.ExitButton.onClick.AddListener(Hide);
            
            _model.OnShow += Show;
            _model.OnHide += Hide;
            _model.OnCardChange += ChangeActiveCard;
        }

        public void Deactivate()
        {
            _cardsPresenters.Deactivate();
            _cardsPresenters.Clear();
            
            _view.ExitButton.onClick.RemoveListener(Hide);
            
            _model.OnShow -= Show;
            _model.OnHide -= Hide;
            _model.OnCardChange -= ChangeActiveCard;
        }

        private void ChangeActiveCard(int changeDirection)
        {
            var activeCard = _model.Cards.Find(card => card.IsActive);
            var nextCard = _model.Cards.Find(card => card.Id == activeCard.Id + changeDirection);
            
            if (nextCard != null)
            {
                activeCard.Hide();
                nextCard.Show();    
            }
            else
            {
                Debug.Log("Next/previous card isn't exist");
            }
        }

        private void Show()
        {
            foreach (var specification in _model.ShipSpecifications)
            {
                var model = new ShopCardDialogModel(specification.Key, specification.Value);
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
            
            _model.Cards.Clear();
            
            _view.DestroyCards();
            _view.ChangeVisibility(false);
            
            _environment.GlobalView.GlobalUIView.MainMenuRoot.SetActive(true);
        }
    }
}