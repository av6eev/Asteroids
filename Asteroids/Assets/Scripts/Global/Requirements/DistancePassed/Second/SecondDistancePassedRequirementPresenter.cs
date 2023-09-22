using Global.Requirements.Base;
using Global.Requirements.DistancePassed.Base;

namespace Global.Requirements.DistancePassed.Second
{
    public class SecondDistancePassedRequirementPresenter : BaseDistancePassedRequirementPresenter<SecondDistancePassedRequirement>
    {
        public SecondDistancePassedRequirementPresenter(IGlobalEnvironment environment, IRequirement model) : base(environment, model) {}
    }
}