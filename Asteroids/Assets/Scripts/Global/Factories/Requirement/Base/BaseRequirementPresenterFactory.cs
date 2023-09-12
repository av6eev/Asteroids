using System.Collections.Generic;
using Global.Requirements.Base;
using Utilities.Interfaces;

namespace Global.Factories.Requirement.Base
{
    public abstract class BaseRequirementPresenterFactory
    {
        public abstract List<IPresenter> CreateList(GlobalEnvironment environment, List<IRequirement> requirements);
    }
}