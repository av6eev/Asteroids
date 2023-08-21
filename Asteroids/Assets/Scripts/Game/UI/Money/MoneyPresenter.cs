using Game.Asteroids;
using Game.Asteroids.Asteroid;
using Global;
using Utilities;

namespace Game.UI.Money
{
    public class MoneyPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly MoneyView _view;

        public MoneyPresenter(GlobalEnvironment environment, MoneyView view)
        {
            _environment = environment;
            _view = view;
        }
        
        public void Activate() => _environment.AsteroidsModel.OnAsteroidDestroyed += UpdateMoneyCounter;

        public void Deactivate() => _environment.AsteroidsModel.OnAsteroidDestroyed -= UpdateMoneyCounter;

        private void UpdateMoneyCounter(AsteroidModel asteroidModel, bool byBorder, bool byShip)
        {
            if (byBorder || byShip) return;

            var moneyBonus = asteroidModel.Specification.Type switch
            {
                AsteroidsTypes.Small => .5f,
                AsteroidsTypes.Medium => 1f,
                AsteroidsTypes.Big => 1.5f,
                AsteroidsTypes.Fire => 1f,
                AsteroidsTypes.Default => 0,
                _ => 0
            };

            _environment.GameModel.UpdateBalance(moneyBonus);
            _view.UpdateMoneyCounter(_environment.GameModel.CurrentMoney);
        }
    }
}