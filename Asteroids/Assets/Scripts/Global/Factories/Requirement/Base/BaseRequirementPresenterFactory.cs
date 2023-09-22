using System.Collections.Generic;
using Global.Base;
using Global.Requirements.Base;
using Utilities.Interfaces;

namespace Global.Factories.Requirement.Base
{
    public abstract class BaseRequirementPresenterFactory
    {
        public abstract List<IPresenter> CreateList(IGlobalEnvironment environment, List<IRequirement> requirements);
    }
}