using Utilities;

namespace Game.Asteroids.Asteroid
{
    public class AsteroidPresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly AsteroidModel _model;
        private readonly AsteroidView _view;

        public AsteroidPresenter(GameEnvironment environment, AsteroidModel model, AsteroidView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _view.SetPosition(_model.Position);
            _model.OnUpdate += Update;
        }

        public void Deactivate()
        {
            _model.OnUpdate -= Update;
        }

        private void Update(float deltaTime)
        {
            Move(deltaTime);
        }
        
        private void Move(float deltaTime)
        {
            var multiplier = _model.Direction * (_model.Specification.Speed * deltaTime);
            
            _model.Position = _view.Move(multiplier);
        }
    }
}