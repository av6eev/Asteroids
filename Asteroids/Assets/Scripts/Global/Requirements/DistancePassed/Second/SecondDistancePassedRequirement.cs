using System;
using Global.Requirements.DistancePassed.Base;
using UnityEngine;

namespace Global.Requirements.DistancePassed.Second
{
    [Serializable]
    public class SecondDistancePassedRequirement : BaseDistancePassedRequirement
    {
        [field: SerializeField] public override string RewardName { get; set; }
        [field: SerializeField] public override int DistanceToPass { get; set; }
    }
}