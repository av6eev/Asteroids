namespace Global.Requirements.Base
{
    public interface IRequirement
    {
        bool IsCompleted { get; }
        SubRequirementType SubType { get; }
        string RewardName { get; set; }
        bool Check(GlobalEnvironment environment);
    }
}