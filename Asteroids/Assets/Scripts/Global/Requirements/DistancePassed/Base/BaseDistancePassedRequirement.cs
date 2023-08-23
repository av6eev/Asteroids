using Global.Requirements.Base;
using UnityEngine;

namespace Global.Requirements.DistancePassed.Base
{
    public class BaseDistancePassedRequirement : IRequirement
    {
        public SubRequirementType SubType { get; } = SubRequirementType.DistancePassed;
        [field: SerializeField] public string RewardName { get; set; }
        [field: SerializeField] public int DistanceToPass { get; set; }
        
        public bool Check(GlobalEnvironment environment)
        {
            if (environment.GameModel.CurrentDistance < DistanceToPass)
            {
                return false;
            }
            
            environment.Specifications.Rewards[RewardName].Give(environment);

            return true;
        }
    }
}