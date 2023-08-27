using Game.Asteroids.Asteroid;
using Game.CameraUpdater;
using Game.Ship.Bullet.Base;
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
        private readonly BaseBulletView _view;

        private HitPullView _hit;
        private Vector3 _spawnOffset;

        public BulletPresenter(GlobalEnvironment environment, BulletModel model, BaseBulletView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _spawnOffset = _environment.GameModel.CurrentDimension switch
            {
                CameraDimensionsTypes.TwoD => new Vector3(0f, 6.5f, 0f),
                CameraDimensionsTypes.ThreeD => new Vector3(0f, 0f, 6.5f),
                _ => _spawnOffset
            };

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