using Global.Rewards.Base;

namespace Specifications.Rewards
{
    public class BaseRewardSpecification<T> : RewardSpecificationSo where T : IReward
    {
        public T Reward;
        public override IReward Get() => Reward;
    }
}