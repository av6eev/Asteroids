using System;
using UnityEngine;
using Utilities.Enums;

namespace Global.Rewards.DistancePassed
{
    [Serializable]
    public class SecondDistancePassedReward : BaseDistancePassedReward
    {
        [field: SerializeField] public override DifficultyStages DifficultyStage { get; set; }
    }
}