using System.Collections.Generic;
using Game.Ship;
using Global.Requirements.MoneyCount.BlueShip;
using UnityEngine;
using Utilities;

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
        }

        public void Deactivate()
        {
            _model.OnSave -= SaveGame;
            _model.OnDeserialize -= DeserializeData;
        }

        private void DeserializeData()
        {
            DeserializeRequirements();
            DeserializePlayerData();
        }

        private void SaveGame()
        {
            Debug.Log("gained: " + _environment.GameModel.CalculateGainedMoney());
            Debug.Log("current: " + _environment.PlayerModel.Money);
            
            _model.SaveElement(SavingElementsKeys.PlayerMoney, _environment.GameModel.CalculateGainedMoney() + _environment.PlayerModel.Money);
            
            DeserializePlayerData();
        }

        private void DeserializePlayerData()
        {
            var playerMoney = _model.GetElement<int>(SavingElementsKeys.PlayerMoney);
                                                                                        
            Debug.Log("deserialized: " + playerMoney);
            _environment.PlayerModel.SetMoneyFromSave(playerMoney);
        }

        private void DeserializeRequirements()
        {
            var requirements = _environment.Specifications.Requirements;
            var availableShips = new Dictionary<ShipsTypes, bool>();
            var type = ShipsTypes.Default;
            var isPurchased = false;

            availableShips.Add(ShipsTypes.Brown, true);

            foreach (var requirement in requirements)
            {
                switch (requirement.Value)
                {
                    case BlueShipMoneyCountRequirement:
                        type = ShipsTypes.Blue;
                        isPurchased = false;
                        _requirementsPresenters.Add(
                            new BlueShipMoneyCountRequirementPresenter(_environment, requirement.Value));
                        break;
                }

                if (_model.GetElement<string>(requirement.Key) == "true")
                {
                    isPurchased = true;
                }

                if (type != ShipsTypes.Default)
                {
                    availableShips.Add(type, isPurchased);
                }
            }

            _environment.GlobalUIModel.SetAvailableShips(availableShips);
            _requirementsPresenters.Activate();
        }
    }
}