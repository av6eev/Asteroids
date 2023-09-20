using Game.UI.Health.Base;
using Global;
using Utilities.Interfaces;

namespace Game.UI.Health
{
    public class HealthPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly IHealthView _view;

        public HealthPresenter(GlobalEnvironment environment, IHealthView view)
        {
            _environment = environment;
            _view = view;
        }
        
        public void Activate()
        {
            _view.SetStartedHealth(_environment.ShipModel.MaxHealth);

            _environment.GameModel.OnLivesChanged += UpdateHealthBar;
        }

        public void Deactivate() => _environment.GameModel.OnLivesChanged -= UpdateHealthBar;

        private void UpdateHealthBar(int currentLives) => _view.UpdateHealth((float)currentLives / (float)_environment.ShipModel.MaxHealth);
    }
}