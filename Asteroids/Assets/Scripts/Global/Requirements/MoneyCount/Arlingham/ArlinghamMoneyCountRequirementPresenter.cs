using Global.Base;
using Global.Requirements.Base;
using Global.Requirements.MoneyCount.Base;

namespace Global.Requirements.MoneyCount.Arlingham
{
    public class ArlinghamMoneyCountRequirementPresenter : BaseMoneyCountRequirementPresenter<ArlinghamMoneyCountRequirement>
    {
        public ArlinghamMoneyCountRequirementPresenter(IGlobalEnvironment environment, IRequirement model) : base(environment, model) {}
    }
}