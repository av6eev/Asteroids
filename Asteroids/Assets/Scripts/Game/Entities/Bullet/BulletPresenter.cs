using Game.Entities.Asteroids.Asteroid;
using Game.Entities.Bullet.Base;
using Global;
using Global.Pulls.ParticleSystem.Hit;
using Global.Sound;
using UnityEngine;
using Utilities.Enums;
using Utilities.Interfaces;

namespace Game.Entities.Bullet
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

            _environment.SoundManager.PlaySound(SoundsTypes.ShipShooting);
            
            _view.SetCurrentPosition(_model.Position + _spawnOffset);
            
            _model.OnUpdate += Update;
            _model.OnDestroy += Destroy;
            
            _view.OnBumped += HandleBump;
        }

        public void Deactivate()
        {
            _model.OnUpdate -= Update;
            _model.OnDestroy -= Destroy;
            
            _view.OnBumped -= HandleBump;
        }

        private void HandleBump(AsteroidModel asteroidModel)
        {
            CreateHitEffect();

            _model.ApplyDamage(asteroidModel.Health);
        }

        private void Destroy() => _environment.ShipModel.ShootModel.DestroyBullet(_model);

        private void Update(float deltaTime) => Move(deltaTime);

        private void Move(float deltaTime) => _model.UpdatePosition(_view.Move(deltaTime));

        private void CreateHitEffect()
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
        }
    }
}