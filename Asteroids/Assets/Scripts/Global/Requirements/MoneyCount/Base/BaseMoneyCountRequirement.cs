using Game.Entities.Ship;
using Global.Base;
using Global.Requirements.Base;

namespace Global.Requirements.MoneyCount.Base
{
    public abstract class BaseMoneyCountRequirement : IRequirement
    {
        public bool IsCompleted { get; set; }
        public SubRequirementType SubType => SubRequirementType.MoneyCount;
        public abstract string RewardName { get; set; }
        public abstract ShipsTypes ShipType { get; set; }

        public bool Check(IGlobalEnvironment environment)
        {
            var chosenShip = environment.Specifications.Ships[ShipType];

            if (environment.PlayerModel.Money < chosenShip.Price)
            {
                return false;
            }

            environment.PlayerModel.ConfirmPurchase(chosenShip);
            environment.Specifications.Rewards[RewardName].Give(environment);

            IsCompleted = true;
            return true;
        }
    }
}