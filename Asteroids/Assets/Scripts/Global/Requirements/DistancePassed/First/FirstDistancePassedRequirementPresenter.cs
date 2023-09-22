using Global.Requirements.Base;
using Global.Requirements.DistancePassed.Base;

namespace Global.Requirements.DistancePassed.First
{
    public class FirstDistancePassedRequirementPresenter : BaseDistancePassedRequirementPresenter<FirstDistancePassedRequirement>
    {
        public FirstDistancePassedRequirementPresenter(IGlobalEnvironment environment, IRequirement model) : base(environment, model) {}
    }
}