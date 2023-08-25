using Global.Requirements.Base;
using Global.Requirements.DistancePassed.Base;

namespace Global.Requirements.DistancePassed.First
{
    public class FirstDistancePassedRequirementPresenter : BaseDistancePassedRequirementPresenter<FirstDistancePassedRequirement>
    {
        public FirstDistancePassedRequirementPresenter(GlobalEnvironment environment, IRequirement model) : base(environment, model) {}
    }
}