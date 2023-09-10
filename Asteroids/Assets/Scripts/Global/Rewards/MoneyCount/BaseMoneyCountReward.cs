using Global.Dialogs.Shop;
using Global.Rewards.Base;

namespace Global.Rewards.MoneyCount
{
    public abstract class BaseMoneyCountReward : IReward
    {
        public bool IsCompleted { get; private set; }

        public void Give(GlobalEnvironment environment)
        {
            IsCompleted = true;
            
            var activeShipCard = environment.DialogsModel.GetByType<ShopDialogModel>().ActiveCard;
            
            environment.GlobalUIModel.SetSelectedShip(activeShipCard.Id);
            environment.GlobalUIModel.UpdateAvailableShips(activeShipCard.ShipSpecification.Type, true);
            environment.DialogsModel.GetByType<ShopDialogModel>().Redraw(activeShipCard.Id);
        }
    }
}