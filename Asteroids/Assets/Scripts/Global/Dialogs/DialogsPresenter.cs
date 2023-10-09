using Global.Base;
using Global.Dialogs.Base;
using Global.Dialogs.History;
using Global.Dialogs.History.Base;
using Global.Dialogs.Shop;
using Global.Dialogs.Shop.Base;
using Utilities.Engines;
using Utilities.Interfaces;

namespace Global.Dialogs
{
    public class DialogsPresenter : IPresenter
    {
        private readonly IGlobalEnvironment _environment;
        private readonly IDialogsModel _model;
        private readonly IDialogsView _view;

        private readonly PresentersEngine _presenters = new();

        public DialogsPresenter(IGlobalEnvironment environment, IDialogsModel model, IDialogsView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _presenters.Add(new ShopDialogPresenter(_environment, _model.GetByType<IShopDialogModel>(), _environment.GlobalSceneView.DialogsView.ShopDialogView));
            _presenters.Add(new HistoryDialogPresenter(_environment, _model.GetByType<IHistoryDialogModel>(), _environment.GlobalSceneView.DialogsView.HistoryDialogView));
            _presenters.Activate();
        }

        public void Deactivate()
        {
            _presenters.Deactivate();
            _presenters.Clear();
        }
    }
}