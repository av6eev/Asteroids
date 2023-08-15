﻿using Global.Save;
using Utilities;

namespace Global.Requirements.Base
{
    public interface IRequirement : ISavable
    {
        bool Completed { get; set; }
        RequirementType Type { get; }
        SubRequirementType SubType { get; }
        bool Check(GlobalEnvironment environment);
    }
}