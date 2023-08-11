using Utilities;

namespace Game.Ship.Shots
{
    public class BulletPresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly BulletModel _model;
        private readonly BulletView _view;

        public BulletPresenter(GameEnvironment environment, BulletModel model, BulletView view)
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