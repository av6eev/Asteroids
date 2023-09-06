using Game.UI.Health.Base;
using Global;
using Utilities.Interfaces;

namespace Game.UI.Health
{
    public class HealthPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly BaseHealthView _view;

        public HealthPresenter(GlobalEnvironment environment, BaseHealthView view)
        {
            _environment = environment;
            _view = view;
        }
        
        public void Activate()
        {
            SetStartedHealth(_environment.ShipModel.Health);

            _environment.ShipModel.OnDamageApplied += UpdateHealthBar;
        }

        public void Deactivate() => _environment.ShipModel.OnDamageApplied -= UpdateHealthBar;

        private void SetStartedHealth(int maxHealth) => _view.SetStartedHealth(maxHealth);

        private void UpdateHealthBar() => _view.UpdateHealth(.33f);
    }
}