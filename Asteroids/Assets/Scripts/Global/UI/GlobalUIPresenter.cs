using System.Collections.Generic;
using System.Linq;
using Game.Entities.Ship;
using Global.Dialogs.History;
using Global.Dialogs.Shop;
using Global.Factories.Requirement;
using Global.Requirements.Base;
using Global.Save;
using UnityEngine;
using Utilities.Engines;
using Utilities.Enums;
using Utilities.Interfaces;

namespace Global.UI
{
    public class GlobalUIPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly IGlobalUIModel _model;
        private readonly GlobalUIView _view;

        private readonly PresentersEngine _requirementsPresenters = new();
        private readonly MoneyCountRequirementPresenterFactory _requirementPresenterFactory = new();

        public GlobalUIPresenter(GlobalEnvironment environment, IGlobalUIModel model, GlobalUIView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            DeserializeRequirements();
            
            _view.MainMenuRoot.SetActive(true);
            _view.PlayButton.onClick.AddListener(StartGame);
            _view.ShopButton.onClick.AddListener(OpenShopMenu);
            _view.HistoryButton.onClick.AddListener(OpenHistoryMenu);
            _view.ExitButton.onClick.AddListener(CloseGame);

            _environment.SaveModel.OnDeserialize += DeserializeData;
        }
        
        public void Deactivate()
        {
            _requirementsPresenters.Deactivate();
            _requirementsPresenters.Clear();
            
            _view.PlayButton.onClick.RemoveListener(StartGame);
            _view.ShopButton.onClick.RemoveListener(OpenShopMenu);
            _view.HistoryButton.onClick.RemoveListener(OpenHistoryMenu);
            _view.ExitButton.onClick.RemoveListener(CloseGame);
            
            _environment.SaveModel.OnDeserialize -= DeserializeData;
        }

        private void OpenShopMenu()
        {
            HideMenuAndTitle();
            
            _environment.DialogsModel.GetByType<ShopDialogModel>().Show();
        }

        private void OpenHistoryMenu()
        {
            HideMenuAndTitle();
            
            _environment.DialogsModel.GetByType<HistoryDialogModel>().Show();
        }

        private void StartGame()
        {
            _view.ChangeVisibility(false);
            _environment.ScenesManager.LoadScene(ScenesNames.GameScene, _environment);
        }

        private void HideMenuAndTitle()
        {
            _view.MainMenuRoot.SetActive(false);
            _view.Title.SetActive(false);
        }

        private void DeserializeData() => _model.SetSelectedShip(_environment.SaveModel.GetElement<int>(SavingElementsKeys.SelectedShip));

        private void DeserializeRequirements()
        {
            var availableShips = new Dictionary<ShipsTypes, bool> { { ShipsTypes.Agasiz, true } };
            var uncompletedRequirements = _requirementPresenterFactory.CreateUncompleted(_environment, new Dictionary<string, IRequirement>(_environment.Specifications.Requirements.Where(item => item.Value.SubType == SubRequirementType.MoneyCount)));

            foreach (var requirement in uncompletedRequirements)
            {
                var isCompleted = requirement.Value == null;
                
                availableShips.Add(requirement.Key, isCompleted);

                if (isCompleted) continue;
                
                _requirementsPresenters.Add(requirement.Value);                    
            }

            _model.SetAvailableShips(availableShips);
            _requirementsPresenters.Activate();
        }
        
        private void CloseGame()
        {
            _environment.SaveModel.Save();
            Application.Quit();
        }
    }
}