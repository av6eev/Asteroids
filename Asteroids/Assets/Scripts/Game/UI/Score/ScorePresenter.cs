using Game.Entities.Asteroids;
using Game.Entities.Asteroids.Asteroid;
using Global;
using Utilities;
using Utilities.Interfaces;

namespace Game.UI.Score
{
    public class ScorePresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly ScoreView _view;

        public ScorePresenter(GlobalEnvironment environment, ScoreView view)
        {
            _environment = environment;
            _view = view;
        }

        public void Activate() => _environment.AsteroidsModel.OnAsteroidDestroyed += UpdateScore;

        public void Deactivate() => _environment.AsteroidsModel.OnAsteroidDestroyed -= UpdateScore;

        private void UpdateScore(AsteroidModel asteroidModel, bool byBorder, bool byShip)
        {
            if (byBorder || byShip) return;

            var scoreBonus = asteroidModel.Specification.Type switch
            {
                AsteroidsTypes.Small => 1,
                AsteroidsTypes.Medium => 2,
                AsteroidsTypes.Big => 3,
                AsteroidsTypes.Fire => 4,
                AsteroidsTypes.Default => 0,
                _ => 0
            };

            _environment.GameModel.UpdateScore(scoreBonus);
            _view.UpdateScore(_environment.GameModel.CurrentScore);
        }
    }
}