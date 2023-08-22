using Utilities;

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
        }

        public void Deactivate()
        {
            _view.ExitButton.onClick.RemoveListener(Hide);

            _model.OnShow -= Show;
            _model.OnHide -= Hide;
            _model.OnScoreAdded -= ResetView;
        }

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