using Global.Rewards.Base;
using UnityEngine;

namespace Specifications.Rewards
{
    public abstract class RewardSpecificationSo : ScriptableObject
    {
        public abstract IReward Get();
    }
}