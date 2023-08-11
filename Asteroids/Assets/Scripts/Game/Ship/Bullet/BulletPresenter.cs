using Game.Asteroids.Asteroid;
using Global.Pulls.ParticleSystem.Hit;
using Utilities;

namespace Game.Ship.Bullet
{
    public class BulletPresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly BulletModel _model;
        private readonly BulletView _view;

        private HitPullView _lastActiveHit;
        
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
            _view.OnBumped += CalculateDamage;
        }

        public void Deactivate()
        {
            _model.OnUpdate -= Update;
            _view.OnBumped -= CalculateDamage;
        }

        private void Update(float deltaTime)
        {
            Move(deltaTime);
        }

        private void CalculateDamage(AsteroidModel asteroidModel)
        {
            if (_lastActiveHit != null)
            {
                _environment.PullsData.HitsPull.PutBack(_lastActiveHit);
            }
    
            _lastActiveHit = _environment.PullsData.HitsPull.TryGetElement();
            _lastActiveHit.transform.position = _view.transform.position;

            _model.Health -= asteroidModel.Health;
            
            if (_model.Health <= 0)
            {
               _environment.ShipModel.ShootModel.DestroyBullet(_model);
            }
        }

        private void Move(float deltaTime)
        {
            _model.Position = _view.Move(deltaTime);
        }
    }
}