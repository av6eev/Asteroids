using System;

namespace Global.Rewards.Base
{
    [Serializable]
    public abstract class BaseReward : IReward
    {
        public abstract void Give(GlobalEnvironment environment);
    }
}