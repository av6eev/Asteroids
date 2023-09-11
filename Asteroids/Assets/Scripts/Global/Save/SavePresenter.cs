using System.Collections.Generic;
using System.Linq;
using Game.Entities.Ship;
using Global.Dialogs.History;
using Global.Requirements.MoneyCount.Arlingham;
using Global.Requirements.MoneyCount.Basilisk;
using Global.Requirements.MoneyCount.Polruan;
using Global.Requirements.MoneyCount.Sartine;
using Utilities.Engines;
using Utilities.Interfaces;

namespace Global.Save
{
    public class SavePresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly ISaveModel _model;

        private readonly PresentersEngine _requirementsPresenters = new();

        public SavePresenter(GlobalEnvironment environment, ISaveModel model)
        {
            _environment = environment;
            _model = model;
        }
        
        public void Activate()
        {
            _model.OnSave += SaveGame;
            _model.OnDeserialize += DeserializeData;
            
            _environment.GlobalUIModel.OnShipChanged += SaveCurrentShip;
        }

        public void Deactivate()
        {
            _requirementsPresenters.Deactivate();
            _requirementsPresenters.Clear();
            
            _model.OnSave -= SaveGame;
            _model.OnDeserialize -= DeserializeData;
            
            _environment.GlobalUIModel.OnShipChanged -= SaveCurrentShip;
        }

        private void DeserializeData()
        {
            DeserializeRequirements();
            DeserializePlayerData();
        }

        private void SaveGame()
        {
            _model.SaveElement(SavingElementsKeys.PlayerMoney, _environment.GameModel.CalculateGainedMoney() + _environment.PlayerModel.Money);
            _model.SaveElement(SavingElementsKeys.ScoresHistory, _environment.DialogsModel.GetByType<HistoryDialogModel>().GetScores());

            foreach (var requirement in _environment.Specifications.Requirements.Where(requirement => requirement.Value.IsCompleted))
            {
                _model.SaveElement(requirement.Key, "true");
            }

            foreach (var reward in _environment.Specifications.Rewards.Where(reward => reward.Value.IsCompleted))
            {
                _model.SaveElement(reward.Key, "true");
            }
                
            DeserializePlayerData();
        }

        private void SaveCurrentShip(int shipId) => _model.SaveElement(SavingElementsKeys.SelectedShip, shipId);

        private void DeserializePlayerData()
        {
            var money = _model.GetElement<int>(SavingElementsKeys.PlayerMoney);
            var scoresHistory = _model.GetElement<List<int>>(SavingElementsKeys.ScoresHistory);
            var lastSelectedShip = _model.GetElement<int>(SavingElementsKeys.SelectedShip);

            _environment.PlayerModel.SetMoneyFromSave(money);
            _environment.DialogsModel.GetByType<HistoryDialogModel>().SetScoresFromSave(scoresHistory);
            _environment.GlobalUIModel.SetSelectedShip(lastSelectedShip);
        }

        private void DeserializeRequirements()
        {
            var requirements = _environment.Specifications.Requirements;
            var availableShips = new Dictionary<ShipsTypes, bool>();
            var type = ShipsTypes.Default;
            IPresenter presenter = null;

            availableShips.Add(ShipsTypes.Agasiz, true);

            foreach (var requirement in requirements)
            {
                var isCompleted = false;

                switch (requirement.Value)
                {
                    case ArlinghamMoneyCountRequirement:
                        type = ShipsTypes.Arlingham;
                        presenter = new ArlinghamMoneyCountRequirementPresenter(_environment, requirement.Value);
                        break;
                    case BasiliskMoneyCountRequirement:
                        type = ShipsTypes.Basilisk;
                        presenter = new BasiliskMoneyCountRequirementPresenter(_environment, requirement.Value);
                        break;
                    case PolruanMoneyCountRequirement:
                        type = ShipsTypes.Polruan;
                        presenter = new PolruanMoneyCountRequirementPresenter(_environment, requirement.Value);
                        break;
                    case SartineMoneyCountRequirement:
                        type = ShipsTypes.Sartine;
                        presenter = new SartineMoneyCountRequirementPresenter(_environment, requirement.Value);
                        break;
                }

                if (type == ShipsTypes.Default) continue;
                if (requirement.Value.IsCompleted) isCompleted = true;
                
                availableShips.Add(type, isCompleted);

                if (presenter == null) continue;
                
                _requirementsPresenters.Add(presenter);
            }

            _environment.GlobalUIModel.SetAvailableShips(availableShips);
            _requirementsPresenters.Activate();
        }
    }
}