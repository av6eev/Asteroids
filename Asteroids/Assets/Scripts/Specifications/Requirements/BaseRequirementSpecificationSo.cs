using Global.Requirements.Base;

namespace Specifications.Requirements
{
    public class BaseRequirementSpecificationSo<T> : RequirementSpecificationSo where T : IRequirement
    {
        public T Requirement;
        public override IRequirement Get() => Requirement;
    }
}