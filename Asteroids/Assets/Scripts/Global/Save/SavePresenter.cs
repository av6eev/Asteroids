using System.Collections.Generic;
using Game.Entities.Ship;
using Global.Dialogs.History;
using Global.Requirements.MoneyCount.BlueShip;
using Utilities;
using Utilities.Engines;
using Utilities.Interfaces;

namespace Global.Save
{
    public class SavePresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly SaveModel _model;

        private readonly PresentersEngine _requirementsPresenters = new();

        public SavePresenter(GlobalEnvironment environment, SaveModel model)
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

            availableShips.Add(ShipsTypes.Brown, true);

            foreach (var requirement in requirements)
            {
                switch (requirement.Value)
                {
                    case BlueShipMoneyCountRequirement:
                        type = ShipsTypes.Blue;
                        availableShips.Add(type, false);
                        _requirementsPresenters.Add(new BlueShipMoneyCountRequirementPresenter(_environment, requirement.Value));
                        break;
                }

                if (_model.GetElement<string>(requirement.Key) == "true")
                {
                    availableShips[type] = true;
                }
            }

            _environment.GlobalUIModel.SetAvailableShips(availableShips);
            _requirementsPresenters.Activate();
        }
    }
}