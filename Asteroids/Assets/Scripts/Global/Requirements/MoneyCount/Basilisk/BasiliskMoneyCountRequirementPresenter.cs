using Global.Requirements.Base;
using Global.Requirements.MoneyCount.Base;

namespace Global.Requirements.MoneyCount.Basilisk
{
    public class BasiliskMoneyCountRequirementPresenter : BaseMoneyCountRequirementPresenter<BasiliskMoneyCountRequirement>
    {
        public BasiliskMoneyCountRequirementPresenter(IGlobalEnvironment environment, IRequirement model) : base(environment, model) {}
    }
}