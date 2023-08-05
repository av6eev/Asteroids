using Utilities;

namespace Global.Dialogs.Shop.Card
{
    public class ShopCardDialogPresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly ShopCardDialogModel _model;
        private readonly ShopCardDialogView _view;

        public ShopCardDialogPresenter(GameEnvironment environment, ShopCardDialogModel model, ShopCardDialogView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _model.OnShow += Show;
        }

        public void Deactivate()
        {
            _model.OnShow -= Show;
        }

        private void Show()
        {
            _view.ChangeVisibility(true);
        }
    }
}