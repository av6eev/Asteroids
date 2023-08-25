namespace Global.Requirements.Base
{
    public interface IRequirement
    {
        SubRequirementType SubType { get; }
        string RewardName { get; set; }
        bool Check(GlobalEnvironment environment);
    }
}