using System.Collections.Generic;
using UnityEngine;

namespace Specifications.Rewards
{
    [CreateAssetMenu(menuName = "Create Specifications Collection/New RewardsData Specification", fileName = "RewardsDataSpecification", order = 51)]
    public class RewardsDataSpecification : ScriptableObject
    {
        public List<RewardSpecificationSo> Rewards;
    }
}