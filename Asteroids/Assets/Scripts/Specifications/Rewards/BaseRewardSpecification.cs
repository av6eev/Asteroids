using Global.Rewards.Base;

namespace Specifications.Rewards
{
    public class BaseRewardSpecification<T> : RewardSpecificationSo where T : BaseReward
    {
        public T Reward;
        public override BaseReward Get() => Reward;
    }
}