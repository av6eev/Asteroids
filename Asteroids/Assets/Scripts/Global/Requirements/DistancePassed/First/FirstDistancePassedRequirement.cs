using System;
using Global.Requirements.DistancePassed.Base;
using UnityEngine;

namespace Global.Requirements.DistancePassed.First
{
    [Serializable]
    public class FirstDistancePassedRequirement : BaseDistancePassedRequirement
    {
        [field: SerializeField] public override string RewardName { get; set; }
        [field: SerializeField] public override int DistanceToPass { get; set; }
    }
}