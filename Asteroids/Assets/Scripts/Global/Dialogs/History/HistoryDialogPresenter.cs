﻿using Utilities;

namespace Global.Dialogs.History
{
    public class HistoryDialogPresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly HistoryDialogModel _model;
        private readonly HistoryDialogView _view;

        public HistoryDialogPresenter(GameEnvironment environment, HistoryDialogModel model, HistoryDialogView view)
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
        }

        public void Deactivate()
        {
            _view.ExitButton.onClick.RemoveListener(Hide);

            _model.OnShow -= Show;
            _model.OnHide -= Hide;
        }

        private void Hide()
        {
            _view.ChangeVisibility(false);
            
            _environment.GlobalView.GlobalUIView.MainMenuRoot.SetActive(true);
        }

        private void Show()
        {
            _view.ChangeVisibility(true);
        }
    }
}