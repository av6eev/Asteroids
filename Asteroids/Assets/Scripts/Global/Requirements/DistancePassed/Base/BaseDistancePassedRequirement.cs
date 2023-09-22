using Global.Base;
using Global.Requirements.Base;

namespace Global.Requirements.DistancePassed.Base
{
    public abstract class BaseDistancePassedRequirement : IRequirement
    {
        public bool IsCompleted { get; set; }
        public SubRequirementType SubType { get; } = SubRequirementType.DistancePassed;
        public abstract string RewardName { get; set; }
        public abstract int DistanceToPass { get; set; }
        
        public bool Check(IGlobalEnvironment environment)
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