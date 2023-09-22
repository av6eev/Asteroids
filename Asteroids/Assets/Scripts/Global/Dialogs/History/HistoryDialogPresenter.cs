using System.Collections.Generic;
using Global.Dialogs.History.Base;
using Global.Save;
using Utilities.Interfaces;

namespace Global.Dialogs.History
{
    public class HistoryDialogPresenter : IPresenter
    {
        private readonly IGlobalEnvironment _environment;
        private readonly IHistoryDialogModel _model;
        private readonly IHistoryDialogView _view;

        public HistoryDialogPresenter(IGlobalEnvironment environment, IHistoryDialogModel model, IHistoryDialogView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _view.Hide();
            _view.InitializeButtonsSubscriptions();
            
            _view.OnExitClicked += Hide;

            _model.OnShow += Show;
            _model.OnHide += Hide;
            _model.OnScoreAdded += ResetView;
            
            _environment.SaveModel.OnDeserialize += DeserializeData;
        }

        public void Deactivate()
        {
            _view.OnExitClicked -= Hide;
            _view.DisposeButtonsSubscriptions();

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
            _view.Show();
        }

        private void Hide()
        {
            _view.Hide();
            _environment.GlobalSceneView.GlobalUIView.ShowDecorationElements();
        }
    }
}