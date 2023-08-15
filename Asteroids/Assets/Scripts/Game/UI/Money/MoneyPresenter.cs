using Global;
using Utilities;

namespace Game.UI.Money
{
    public class MoneyPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly MoneyModel _model;
        private readonly MoneyView _view;

        public MoneyPresenter(GlobalEnvironment environment, MoneyModel model, MoneyView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _environment.PlayerModel.OnMoneyIncreased += UpdateMoneyCounter;
        }

        public void Deactivate()
        {
            _environment.PlayerModel.OnMoneyIncreased -= UpdateMoneyCounter;
        }
        
        private void UpdateMoneyCounter(int bonus)
        {
            _model.UpdateBalance(bonus);
            _view.UpdateMoneyCounter(_model.MoneyGained);
        }
    }
}