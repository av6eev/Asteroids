﻿using Global.Save;
using Utilities.Interfaces;

namespace Global.Player
{
    public class PlayerPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly PlayerModel _model;

        public PlayerPresenter(GlobalEnvironment environment, PlayerModel model)
        {
            _environment = environment;
            _model = model;
        }
        
        public void Activate() => _model.OnPurchaseConfirmed += HandlePurchase;

        public void Deactivate() => _model.OnPurchaseConfirmed -= HandlePurchase;

        private void HandlePurchase(IPurchaseable data)
        {
            _model.DecreaseMoney(data.Price);
            _environment.SaveModel.SaveElement(SavingElementsKeys.PlayerMoney, _model.Money);
        }
    }
}