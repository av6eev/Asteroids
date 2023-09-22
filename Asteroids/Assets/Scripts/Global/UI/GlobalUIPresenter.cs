using System.Collections.Generic;
using System.Linq;
using Game.Entities.Ship;
using Global.Dialogs.History.Base;
using Global.Dialogs.Shop.Base;
using Global.Factories.Requirement;
using Global.Requirements.Base;
using Global.Save;
using Global.UI.Base;
using Utilities.Engines;
using Utilities.Enums;
using Utilities.Interfaces;

namespace Global.UI
{
    public class GlobalUIPresenter : IPresenter
    {
        private readonly IGlobalEnvironment _environment;
        private readonly IGlobalUIModel _model;
        private readonly IGlobalUIView _view;

        private readonly PresentersEngine _requirementsPresenters = new();
        private readonly MoneyCountRequirementPresenterFactory _requirementPresenterFactory = new();

        public GlobalUIPresenter(IGlobalEnvironment environment, IGlobalUIModel model, IGlobalUIView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            DeserializeRequirements();
            
            _view.ShowDecorationElements();
            _view.InitializeButtonsSubscriptions();
            _view.OnPlayClicked += StartGame;
            _view.OnShopClicked += OpenShopMenu;
            _view.OnHistoryClicked += OpenHistoryMenu;
            _view.OnExitClicked += CloseGame;

            _environment.SaveModel.OnDeserialize += DeserializeData;
        }
        
        public void Deactivate()
        {
            _requirementsPresenters.Deactivate();
            _requirementsPresenters.Clear();
            
            _view.OnPlayClicked -= StartGame;
            _view.OnShopClicked -= OpenShopMenu;
            _view.OnHistoryClicked -= OpenHistoryMenu;
            _view.OnExitClicked -= CloseGame;
            _view.DisposeButtonsSubscriptions();

            _environment.SaveModel.OnDeserialize -= DeserializeData;
        }

        private void OpenShopMenu()
        {
            _view.HideDecorationElements();
            
            _environment.DialogsModel.GetByType<IShopDialogModel>().Show();
        }

        private void OpenHistoryMenu()
        {
            _view.HideDecorationElements();
            
            _environment.DialogsModel.GetByType<IHistoryDialogModel>().Show();
        }

        private void StartGame()
        {
            _view.Hide();
            _environment.ScenesManager.LoadScene(ScenesNames.GameScene, _environment);
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
        
        private void CloseGame() => _environment.SaveModel.Save();
    }
}