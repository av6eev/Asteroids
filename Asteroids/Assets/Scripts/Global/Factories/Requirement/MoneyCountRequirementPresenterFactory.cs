using System.Collections.Generic;
using System.Linq;
using Game.Entities.Ship;
using Global.Factories.Requirement.Base;
using Global.Requirements.Base;
using Global.Requirements.MoneyCount.Arlingham;
using Global.Requirements.MoneyCount.Basilisk;
using Global.Requirements.MoneyCount.Polruan;
using Global.Requirements.MoneyCount.Sartine;
using Global.Save;
using Utilities.Interfaces;

namespace Global.Factories.Requirement
{
    public class MoneyCountRequirementPresenterFactory : BaseRequirementPresenterFactory
    {
        public override List<IPresenter> CreateList(GlobalEnvironment environment, List<IRequirement> requirements)
        {
            return requirements.Select(requirement => (IPresenter)(requirement switch
                {
                    ArlinghamMoneyCountRequirement => new ArlinghamMoneyCountRequirementPresenter(environment, requirement),
                    BasiliskMoneyCountRequirement => new BasiliskMoneyCountRequirementPresenter(environment, requirement),
                    PolruanMoneyCountRequirement => new PolruanMoneyCountRequirementPresenter(environment, requirement),
                    SartineMoneyCountRequirement => new SartineMoneyCountRequirementPresenter(environment, requirement),
                    _ => null
                }))
                .ToList();
        }

        public Dictionary<ShipsTypes, IPresenter> CreateUncompleted(GlobalEnvironment environment, in Dictionary<string, IRequirement> requirements)
        {
            Dictionary<ShipsTypes, IPresenter> uncompletedRequirements = new ();
            var type = ShipsTypes.Default;
            IPresenter presenter = null;
            
            foreach (var requirement in requirements)
            {
                var isCompleted = environment.SaveModel.GetElement<string>(requirement.Key) == SavingElementsKeys.Completed;

                if (isCompleted)
                {
                    requirement.Value.IsCompleted = true;
                }
                
                switch (requirement.Value)
                {
                    case ArlinghamMoneyCountRequirement:
                        type = ShipsTypes.Arlingham;
                        presenter = new ArlinghamMoneyCountRequirementPresenter(environment, requirement.Value);
                        break;
                    case BasiliskMoneyCountRequirement:
                        type = ShipsTypes.Basilisk;
                        presenter = new BasiliskMoneyCountRequirementPresenter(environment, requirement.Value);
                        break;
                    case PolruanMoneyCountRequirement:
                        type = ShipsTypes.Polruan;
                        presenter = new PolruanMoneyCountRequirementPresenter(environment, requirement.Value);
                        break;
                    case SartineMoneyCountRequirement:
                        type = ShipsTypes.Sartine;
                        presenter = new SartineMoneyCountRequirementPresenter(environment, requirement.Value);
                        break;
                }

                uncompletedRequirements.Add(type, isCompleted ? null : presenter);
            }

            return uncompletedRequirements;
        }
    }
}