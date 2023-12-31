﻿using Global.Base;
using Global.Rewards.Base;
using Utilities.Enums;

namespace Global.Rewards.DistancePassed
{
    public abstract class BaseDistancePassedReward : IReward
    {
        public bool IsCompleted { get; private set; }
        public abstract DifficultyStages DifficultyStage { get; set; }

        public void Give(IGlobalEnvironment environment)
        {
            IsCompleted = true;
            environment.GameModel.UpdateDifficulty(environment.Specifications.GameDifficulties[DifficultyStage]);
        }
    }
}