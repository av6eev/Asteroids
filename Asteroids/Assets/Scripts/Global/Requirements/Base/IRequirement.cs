using Global.Save;

namespace Global.Requirements.Base
{
    public interface IRequirement : ISavable
    {
        bool Completed { get; set; }
        SubRequirementType SubType { get; }
        string RewardName { get; set; }
        bool Check(GlobalEnvironment environment);
    }
}