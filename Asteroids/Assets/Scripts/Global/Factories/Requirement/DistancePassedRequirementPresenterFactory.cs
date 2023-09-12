using System.Collections.Generic;
using System.Linq;
using Global.Factories.Requirement.Base;
using Global.Requirements.Base;
using Global.Requirements.DistancePassed.First;
using Global.Requirements.DistancePassed.Second;
using Global.Requirements.DistancePassed.Third;
using Utilities.Interfaces;

namespace Global.Factories.Requirement
{
    public class DistancePassedRequirementPresenterFactory : BaseRequirementPresenterFactory
    {
        public override List<IPresenter> CreateList(GlobalEnvironment environment, List<IRequirement> requirements)
        {
            return requirements.Select(requirement => (IPresenter)(requirement switch
                {
                    FirstDistancePassedRequirement => new FirstDistancePassedRequirementPresenter(environment, requirement),
                    SecondDistancePassedRequirement => new SecondDistancePassedRequirementPresenter(environment, requirement),
                    ThirdDistancePassedRequirement => new ThirdDistancePassedRequirementPresenter(environment, requirement),
                    _ => null
                }))
                .ToList();
        }
    }
}