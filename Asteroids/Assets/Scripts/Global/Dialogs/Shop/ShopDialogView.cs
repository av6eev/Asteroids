﻿using System;
using System.Collections.Generic;
using Global.Dialogs.Shop.Base;
using Global.Dialogs.Shop.Card;
using Specifications.Ships;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Global.Dialogs.Shop
{
    public class ShopDialogView : MonoBehaviour, IShopDialogView
    {
        public event Action OnExitClicked;
        [field: SerializeField] public ShopCardDialogView ShopCardPrefab { get; private set; }
        [field: SerializeField] public Button ExitButton { get; private set; }
        [field: SerializeField] public TextMeshProUGUI PlayerMoneyTxt { get; private set; }

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

        public void UpdateBalanceText(int money) => PlayerMoneyTxt.text = money.ToString();

        public void InitializeButtonsSubscriptions() => ExitButton.onClick.AddListener(() => { OnExitClicked?.Invoke(); });

        public void DisposeButtonsSubscriptions() => ExitButton.onClick.RemoveListener(() => { OnExitClicked?.Invoke(); });

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}