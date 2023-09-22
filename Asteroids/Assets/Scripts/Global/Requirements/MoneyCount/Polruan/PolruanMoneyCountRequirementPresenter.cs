using Global.Requirements.Base;
using Global.Requirements.MoneyCount.Base;

namespace Global.Requirements.MoneyCount.Polruan
{
    public class PolruanMoneyCountRequirementPresenter : BaseMoneyCountRequirementPresenter<PolruanMoneyCountRequirement>
    {
        public PolruanMoneyCountRequirementPresenter(IGlobalEnvironment environment, IRequirement model) : base(environment, model) {}
    }
}