using Global.Base;
using Global.Dialogs.History.Base;
using Global.Save.Base;
using Utilities.Engines;
using Utilities.Interfaces;

namespace Global.Save
{
    public class SavePresenter : IPresenter
    {
        private readonly IGlobalEnvironment _environment;
        private readonly ISaveModel _model;

        private readonly PresentersEngine _requirementsPresenters = new();

        public SavePresenter(IGlobalEnvironment environment, ISaveModel model)
        {
            _environment = environment;
            _model = model;
        }
        
        public void Activate()
        {
            _model.OnSave += SaveGame;
            
            _environment.GlobalUIModel.OnShipChanged += SaveCurrentShip;
        }

        public void Deactivate()
        {
            _requirementsPresenters.Deactivate();
            _requirementsPresenters.Clear();
            
            _model.OnSave -= SaveGame;
            
            _environment.GlobalUIModel.OnShipChanged -= SaveCurrentShip;
        }

        private void SaveGame()
        {
            _model.SaveElement(SavingElementsKeys.PlayerMoney, _environment.PlayerModel.Money);
            _model.SaveElement(SavingElementsKeys.ScoresHistory, _environment.DialogsModel.GetByType<IHistoryDialogModel>().GetScores());

            foreach (var requirement in _environment.Specifications.Requirements)
            {
                _model.SaveElement(requirement.Key, requirement.Value.IsCompleted ? SavingElementsKeys.Completed : SavingElementsKeys.Uncompleted);
            }

            foreach (var reward in _environment.Specifications.Rewards)
            {
                _model.SaveElement(reward.Key, reward.Value.IsCompleted ? SavingElementsKeys.Completed : SavingElementsKeys.Uncompleted);
            }
        }

        private void SaveCurrentShip(int shipId) => _model.SaveElement(SavingElementsKeys.SelectedShip, shipId);
    }
}