using System.Collections.Generic;
using Global.Save;
using Utilities.Interfaces;

namespace Global.Dialogs.History
{
    public class HistoryDialogPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly HistoryDialogModel _model;
        private readonly HistoryDialogView _view;

        public HistoryDialogPresenter(GlobalEnvironment environment, HistoryDialogModel model, HistoryDialogView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _view.ChangeVisibility(false);
            _view.ExitButton.onClick.AddListener(Hide);

            _model.OnShow += Show;
            _model.OnHide += Hide;
            _model.OnScoreAdded += ResetView;
            
            _environment.SaveModel.OnDeserialize += DeserializeData;
        }

        public void Deactivate()
        {
            _view.ExitButton.onClick.RemoveListener(Hide);

            _model.OnShow -= Show;
            _model.OnHide -= Hide;
            _model.OnScoreAdded -= ResetView;
            
            _environment.SaveModel.OnDeserialize -= DeserializeData;
        }

        private void DeserializeData() => _model.SetScoresFromSave(_environment.SaveModel.GetElement<List<int>>(SavingElementsKeys.ScoresHistory));

        private void ResetView() => _view.SetScores(_model.GetScores());

        private void Show()
        {
            _view.SetScores(_model.GetScores());
            _view.ChangeVisibility(true);
        }

        private void Hide()
        {
            _view.ChangeVisibility(false);
            
            _environment.GlobalView.GlobalUIView.MainMenuRoot.SetActive(true);
            _environment.GlobalView.GlobalUIView.Title.SetActive(true);
        }
    }
}