using Global.Dialogs.Base;
using Global.Dialogs.History;
using Global.Dialogs.Shop;
using Utilities.Engines;
using Utilities.Interfaces;

namespace Global.Dialogs
{
    public class DialogsPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly IDialogsModel _model;
        private readonly IDialogsView _view;

        private readonly PresentersEngine _presenters = new();

        public DialogsPresenter(GlobalEnvironment environment, IDialogsModel model, IDialogsView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _presenters.Add(new ShopDialogPresenter(_environment, _model.GetByType<ShopDialogModel>(), _view.ShopDialogView));
            _presenters.Add(new HistoryDialogPresenter(_environment, _model.GetByType<HistoryDialogModel>(), _view.HistoryDialogView));
            _presenters.Activate();
        }

        public void Deactivate()
        {
            _presenters.Deactivate();
            _presenters.Clear();
        }
    }
}