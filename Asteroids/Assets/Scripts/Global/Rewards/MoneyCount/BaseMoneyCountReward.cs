using Global.Base;
using Global.Dialogs.Shop.Base;
using Global.Rewards.Base;

namespace Global.Rewards.MoneyCount
{
    public abstract class BaseMoneyCountReward : IReward
    {
        public bool IsCompleted { get; private set; }

        public void Give(IGlobalEnvironment environment)
        {
            IsCompleted = true;
            
            var activeShipCard = environment.DialogsModel.GetByType<IShopDialogModel>().ActiveCard;
            
            environment.GlobalUIModel.SetSelectedShip(activeShipCard.Id);
            environment.GlobalUIModel.UpdateAvailableShips(activeShipCard.ShipType, true);
            environment.DialogsModel.GetByType<IShopDialogModel>().Redraw(activeShipCard.Id);
        }
    }
}