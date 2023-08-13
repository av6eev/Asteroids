using Game.Ship;
using Global.Requirements.Base;

namespace Global.Requirements.MoneyCount
{
    public abstract class BaseMoneyCountRequirement : SingleRequirement
    {
        public override bool Completed { get; set; }
        public override SubRequirementType SubType { get; } = SubRequirementType.MoneyCount;
        public override string RewardName { get; protected set; }
        public abstract ShipsTypes ShipType { get; protected set; }

        public override bool Check(GlobalEnvironment environment)
        {
            var chosenShipPrice = environment.Specifications.Ships[ShipType].Price;

            if (environment.PlayerModel.Money < chosenShipPrice)
            {
                return false;
            }
            
            environment.Specifications.Rewards[RewardName].Give(environment);
            
            Completed = true;
            return true;
        }
    }
}