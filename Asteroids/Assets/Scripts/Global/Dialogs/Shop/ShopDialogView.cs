using System;
using System.Collections.Generic;
using Global.Dialogs.Base;
using Global.Dialogs.Shop.Card;
using Specifications.Ships;
using UnityEngine;
using UnityEngine.UI;

namespace Global.Dialogs.Shop
{
    public class ShopDialogView : BaseDialogView
    {
        [field: SerializeField] public ShopCardDialogView ShopCardPrefab { get; private set; }
        [field: SerializeField] public Button ExitButton { get; private set; }

        [NonSerialized] private readonly List<ShopCardDialogView> _cardsViews = new();

        public ShopCardDialogView InstantiateCard(ShipSpecification specification)
        {
            var cardView = Instantiate(ShopCardPrefab, transform);

            cardView.SetupCard(specification);
            
            cardView.transform.SetParent(transform);
            cardView.gameObject.SetActive(false);

            _cardsViews.Add(cardView);
            return cardView;
        }

        public void DestroyCards()
        {
            foreach (var card in _cardsViews)
            {
                Destroy(card.gameObject);
            }
            
            _cardsViews.Clear();
        }
    }
}