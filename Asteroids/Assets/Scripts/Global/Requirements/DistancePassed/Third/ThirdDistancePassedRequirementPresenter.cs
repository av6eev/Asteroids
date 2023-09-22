using Global.Requirements.Base;
using Global.Requirements.DistancePassed.Base;

namespace Global.Requirements.DistancePassed.Third
{
    public class ThirdDistancePassedRequirementPresenter : BaseDistancePassedRequirementPresenter<ThirdDistancePassedRequirement>
    {
        public ThirdDistancePassedRequirementPresenter(IGlobalEnvironment environment, IRequirement model) : base(environment, model) {}
    }
}