﻿using Game.Entities.Asteroids.Asteroid.Base;
using Game.Entities.Bullet.Base;
using Global;
using Global.Base;
using Global.Sound;
using UnityEngine;
using Utilities.Interfaces;

namespace Game.Entities.Bullet
{
    public class BulletPresenter : IPresenter
    {
        private readonly IGlobalEnvironment _environment;
        private readonly IBulletModel _model;
        private readonly IBulletView _view;

        public BulletPresenter(IGlobalEnvironment environment, IBulletModel model, IBulletView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _environment.GlobalSceneView.SoundManager.Instance.Play(SoundsTypes.ShipShooting);
            
            _view.SetCurrentPosition(_model.Position);
            
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

        private void HandleBump(IAsteroidModel asteroidModel)
        {
            CreateHitEffect();

            _model.ApplyDamage(asteroidModel.CurrentHealth);
        }

        private void Destroy() => _environment.ShipModel.ShootModel.DestroyBullet(_model);

        private void Update(float deltaTime) => Move(deltaTime);

        private void Move(float deltaTime) => _model.UpdatePosition(_view.Move(deltaTime));

        private void CreateHitEffect()
        {
            var hitsPull = _environment.PullsModel.HitsPull;
            var lastActiveHit = hitsPull.LastActiveHit;

            if (lastActiveHit != null)
            {
                hitsPull.PutBack(lastActiveHit);
                hitsPull.LastActiveHit = null;
            }

            var hit = hitsPull.TryGetElement();
            ((MonoBehaviour)hit).transform.position = _model.Position;
            
            hitsPull.LastActiveHit = hit;
        }
    }
}