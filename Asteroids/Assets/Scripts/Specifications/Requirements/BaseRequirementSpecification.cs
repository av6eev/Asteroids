using Global.Requirements.Base;

namespace Specifications.Requirements
{
    public class BaseRequirementSpecification<T> : RequirementSpecificationSo where T : IRequirement
    {
        public T Requirement;
        public override IRequirement Get() => Requirement;
    }
}