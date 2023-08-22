using System.Linq;
using Global.Dialogs.Shop;
using Global.Rewards.Base;

namespace Global.Rewards.MoneyCount
{
    public class BaseMoneyCountReward : BaseReward
    {
        public override void Give(GlobalEnvironment environment)
        {
            var activeShipCard = environment.DialogsModel.GetByType<ShopDialogModel>().Cards.First(card => card.IsActive);
            
            environment.PlayerModel.ConfirmPurchase(activeShipCard.ShipSpecification);
        }
    }
}