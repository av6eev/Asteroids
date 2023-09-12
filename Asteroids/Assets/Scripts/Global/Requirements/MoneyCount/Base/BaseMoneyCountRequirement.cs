using Game.Entities.Ship;
using Global.Requirements.Base;
using UnityEngine;

namespace Global.Requirements.MoneyCount.Base
{
    public abstract class BaseMoneyCountRequirement : IRequirement
    {
        public bool IsCompleted { get; set; }
        public SubRequirementType SubType => SubRequirementType.MoneyCount;
        [field: SerializeField] public string RewardName { get; set; }
        [field: SerializeField] public ShipsTypes ShipType { get; private set; }

        public bool Check(GlobalEnvironment environment)
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