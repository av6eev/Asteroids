using Global.Dialogs.Shop;
using Global.Save;
using Specifications.Ships;
using Utilities;

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

            if (data is not ShipSpecification shipSpecification) return;
            
            _environment.DialogsModel.GetByType<ShopDialogModel>().Redraw(shipSpecification.Id);
            _environment.SaveModel.SaveElement(SavingElementsKeys.PlayerMoney, _model.Money);
        }
    }
}