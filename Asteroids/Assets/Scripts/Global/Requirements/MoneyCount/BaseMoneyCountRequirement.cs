using Game.Ship;
using Global.Requirements.Base;
using UnityEngine;

namespace Global.Requirements.MoneyCount
{
    public abstract class BaseMoneyCountRequirement : IRequirement
    {
        public bool Completed { get; set; }
        public SubRequirementType SubType => SubRequirementType.MoneyCount;
        [field: SerializeField] public string RewardName { get; set; }
        [field: SerializeField] public ShipsTypes ShipType { get; private set; }

        public bool Check(GlobalEnvironment environment)
        {
            var chosenShipPrice = environment.Specifications.Ships[ShipType].Price;

            if (environment.PlayerModel.Money < chosenShipPrice)
            {
                Debug.Log(chosenShipPrice);
                Debug.Log(environment.PlayerModel.Money);
                return false;
            }
            
            environment.Specifications.Rewards[RewardName].Give(environment);
            
            Completed = true;
            return true;
        }
    }
}