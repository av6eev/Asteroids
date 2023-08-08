using Utilities;

namespace Game.Ship.Shots.Shot
{
    public class ShotPresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly ShotModel _model;
        private readonly ShotView _view;

        public ShotPresenter(GameEnvironment environment, ShotModel model, ShotView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _view.SetCurrentPosition(_model.Position);
            
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
            _model.Position = _view.Move(deltaTime);
        }
    }
}