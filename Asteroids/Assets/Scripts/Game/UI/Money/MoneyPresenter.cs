using Game.Entities.Asteroids;
using Game.Entities.Asteroids.Asteroid.Base;
using Game.UI.Money.Base;
using Global;
using Global.Sound;
using Utilities.Interfaces;

namespace Game.UI.Money
{
    public class MoneyPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly IMoneyView _view;

        public MoneyPresenter(GlobalEnvironment environment, IMoneyView view)
        {
            _environment = environment;
            _view = view;
        }
        
        public void Activate() => _environment.AsteroidsModel.OnAsteroidDestroyed += UpdateMoneyCounter;

        public void Deactivate() => _environment.AsteroidsModel.OnAsteroidDestroyed -= UpdateMoneyCounter;

        private void UpdateMoneyCounter(IAsteroidModel asteroidModel, bool byBorder, bool byShip)
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
            _environment.GlobalSceneView.SoundManager.Instance.Play(SoundsTypes.CoinGained);
            
            _view.UpdateMoneyCounter(_environment.GameModel.CurrentMoney);
        }
    }
}