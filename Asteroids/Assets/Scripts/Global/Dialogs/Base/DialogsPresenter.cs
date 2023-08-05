using Global.Dialogs.Shop;
using Utilities;

namespace Global.Dialogs.Base
{
    public class DialogsPresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly DialogsModel _model;
        private readonly DialogsView _view;

        private readonly PresentersEngine _presenters = new();

        public DialogsPresenter(GameEnvironment environment, DialogsModel model, DialogsView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _presenters.Add(new ShopDialogPresenter(_environment, _model.GetByType<ShopDialogModel>(), _view.ShopDialogView));
            _presenters.Activate();
        }

        public void Deactivate()
        {
            _presenters.Deactivate();
            _presenters.Clear();
        }
    }
}