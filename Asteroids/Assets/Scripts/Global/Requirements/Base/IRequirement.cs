﻿using Global.Base;

namespace Global.Requirements.Base
{
    public interface IRequirement
    {
        bool IsCompleted { get; set; }
        SubRequirementType SubType { get; }
        string RewardName { get; set; }
        bool Check(IGlobalEnvironment environment);
    }
}