using Global.Requirements.Base;
using Global.Requirements.MoneyCount.Base;

namespace Global.Requirements.MoneyCount.Arlingham
{
    public class ArlinghamMoneyCountRequirementPresenter : BaseMoneyCountRequirementPresenter<ArlinghamMoneyCountRequirement>
    {
        public ArlinghamMoneyCountRequirementPresenter(GlobalEnvironment environment, IRequirement model) : base(environment, model) {}
    }
}