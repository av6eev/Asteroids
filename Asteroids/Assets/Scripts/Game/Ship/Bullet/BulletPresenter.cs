using Game.Asteroids.Asteroid;
using Global;
using Global.Pulls.ParticleSystem.Hit;
using UnityEngine;
using Utilities;

namespace Game.Ship.Bullet
{
    public class BulletPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly BulletModel _model;
        private readonly BulletView _view;

        private HitPullView _hit;
        private readonly Vector3 _spawnOffset = new Vector3(0f, 0f, 4.5f);

        public BulletPresenter(GlobalEnvironment environment, BulletModel model, BulletView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _view.SetCurrentPosition(_model.Position + _spawnOffset);
            
            _model.OnUpdate += Update;
            _view.OnBumped += CalculateDamage;
        }

        public void Deactivate()
        {
            _model.OnUpdate -= Update;
            _view.OnBumped -= CalculateDamage;
        }

        private void CalculateDamage(AsteroidModel asteroidModel)
        {
            var hitsPull = _environment.PullsData.HitsPull;
            var lastActiveHit = hitsPull.LastActiveHit;
            
            if (lastActiveHit != null)
            {
                hitsPull.PutBack(lastActiveHit);
                hitsPull.LastActiveHit = null;
            }
            
            _hit = hitsPull.TryGetElement();
            _hit.transform.position = _view.transform.position;

            hitsPull.LastActiveHit = _hit;
            
            _model.Health -= asteroidModel.Health;
            
            if (_model.Health <= 0)
            {
               _environment.ShipModel.ShootModel.DestroyBullet(_model);
            }
        }

        private void Update(float deltaTime) => Move(deltaTime);

        private void Move(float deltaTime) => _model.Position = _view.Move(deltaTime);
    }
}