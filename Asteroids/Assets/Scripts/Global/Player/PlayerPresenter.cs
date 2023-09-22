using Global.Base;
using Global.Player.Base;
using Global.Save;
using Utilities.Interfaces;

namespace Global.Player
{
    public class PlayerPresenter : IPresenter
    {
        private readonly IGlobalEnvironment _environment;
        private readonly IPlayerModel _model;

        public PlayerPresenter(IGlobalEnvironment environment, IPlayerModel model)
        {
            _environment = environment;
            _model = model;
        }
        
        public void Activate()
        {
            _model.OnPurchaseConfirmed += HandlePurchase;
            
            _environment.SaveModel.OnDeserialize += DeserializeData;
        }

        public void Deactivate()
        {
            _model.OnPurchaseConfirmed -= HandlePurchase;
            
            _environment.SaveModel.OnDeserialize -= DeserializeData;
        }

        private void DeserializeData() => _model.SetMoneyFromSave(_environment.SaveModel.GetElement<int>(SavingElementsKeys.PlayerMoney));

        private void HandlePurchase(IPurchaseable data)
        {
            _model.DecreaseMoney(data.Price);
            _environment.SaveModel.SaveElement(SavingElementsKeys.PlayerMoney, _model.Money);
        }
    }
}