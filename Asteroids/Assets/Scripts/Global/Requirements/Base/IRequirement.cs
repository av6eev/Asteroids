using Utilities;

namespace Global.Requirements.Base
{
    public interface IRequirement
    {
        bool Completed { get; set; }
        RequirementType Type { get; }
        SubRequirementType SubType { get; }
        bool Check(GlobalEnvironment environment);
    }
}