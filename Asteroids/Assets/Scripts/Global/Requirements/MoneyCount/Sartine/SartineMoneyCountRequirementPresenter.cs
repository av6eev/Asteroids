using Global.Requirements.Base;
using Global.Requirements.MoneyCount.Base;

namespace Global.Requirements.MoneyCount.Sartine
{
    public class SartineMoneyCountRequirementPresenter : BaseMoneyCountRequirementPresenter<SartineMoneyCountRequirement>
    {
        public SartineMoneyCountRequirementPresenter(GlobalEnvironment environment, IRequirement model) : base(environment, model) {}
    }
}