using Global.Requirements.Base;
using UnityEngine;

namespace Specifications.Requirements
{
    public abstract class RequirementSpecificationSo : ScriptableObject
    {
        public abstract IRequirement Get();
    }
}