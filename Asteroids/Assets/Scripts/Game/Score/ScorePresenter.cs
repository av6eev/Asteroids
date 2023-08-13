using Game.Asteroids;
using Game.Asteroids.Asteroid;
using Global;
using Utilities;

namespace Game.Score
{
    public class ScorePresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly ScoreModel _model;
        private readonly ScoreView _view;

        public ScorePresenter(GlobalEnvironment environment, ScoreModel model, ScoreView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }

        public void Activate()
        {
            _environment.AsteroidsModel.OnAsteroidDestroyed += UpdateScore;
        }

        public void Deactivate()
        {
            _environment.AsteroidsModel.OnAsteroidDestroyed -= UpdateScore;
        }

        private void UpdateScore(AsteroidModel asteroidModel)
        {
            var bonus = asteroidModel.Specification.Type switch
            {
                AsteroidsTypes.Small => 1,
                AsteroidsTypes.Medium => 2,
                AsteroidsTypes.Big => 3,
                AsteroidsTypes.Fire => 4,
                _ => 0
            };
            
            _model.UpdateScore(bonus);
            _view.UpdateScore(_model.CurrentScore);
        }
    }
}