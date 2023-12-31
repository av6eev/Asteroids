﻿using Global.Base;

namespace Global.Rewards.Base
{
    public interface IReward
    {
        bool IsCompleted { get; }
        void Give(IGlobalEnvironment environment);
    }
}