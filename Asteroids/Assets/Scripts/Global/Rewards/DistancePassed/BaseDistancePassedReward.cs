using Global.Rewards.Base;
using UnityEngine;
using Utilities;
using Utilities.Enums;

namespace Global.Rewards.DistancePassed
{
    public class BaseDistancePassedReward : IReward
    {
        [field: SerializeField] public DifficultyStages DifficultyStage { get; private set; }
        
        public void Give(GlobalEnvironment environment)
        {
            environment.GameModel.UpdateDifficulty(environment.Specifications.GameDifficulties[DifficultyStage]);
        }
    }
}