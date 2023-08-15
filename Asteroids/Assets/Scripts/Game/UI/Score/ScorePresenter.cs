using Game.Asteroids;
using Game.Asteroids.Asteroid;
using Global;
using Utilities;

namespace Game.UI.Score
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

        private void UpdateScore(AsteroidModel asteroidModel, bool byBorder)
        {
            int scoreBonus;
            int moneyBonus;

            if (byBorder) return;
            
            switch (asteroidModel.Specification.Type)
            {
                case AsteroidsTypes.Small:
                    scoreBonus = 1;
                    moneyBonus = 1;
                    break;
                case AsteroidsTypes.Medium:
                    scoreBonus = 2;
                    moneyBonus = 2;
                    break;
                case AsteroidsTypes.Big:
                    scoreBonus = 3;
                    moneyBonus = 3;
                    break;
                case AsteroidsTypes.Fire:
                    scoreBonus = 4;
                    moneyBonus = 4;
                    break;
                case AsteroidsTypes.Default:
                    scoreBonus = 0;
                    moneyBonus = 0;
                    break;
                default:
                    scoreBonus = 0;
                    moneyBonus = 0;
                    break;
            }
            
            _environment.PlayerModel.IncreaseMoney(moneyBonus);
            _model.UpdateScore(scoreBonus);
            _view.UpdateScore(_model.CurrentScore);
        }
    }
}