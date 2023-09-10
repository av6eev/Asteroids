using Global.Rewards.Base;
using UnityEngine;
using Utilities.Enums;

namespace Global.Rewards.DistancePassed
{
    public abstract class BaseDistancePassedReward : IReward
    {
        public bool IsCompleted { get; private set; }
        [field: SerializeField] public DifficultyStages DifficultyStage { get; private set; }

        public void Give(GlobalEnvironment environment)
        {
            IsCompleted = true;
            environment.GameModel.UpdateDifficulty(environment.Specifications.GameDifficulties[DifficultyStage]);
        }
    }
}