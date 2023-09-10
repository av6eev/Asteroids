using System;
using Game.Entities.Asteroids.Asteroid.Base;
using Global.Pulls.Base;
using Global.Pulls.ParticleSystem.Hit;
using UnityEngine;

namespace Game.Entities.Bullet.Base
{
    public abstract class BaseBulletView : BasePullElementView
    {
        public event Action<IAsteroidModel> OnBumped; 
        
        public abstract float Speed { get; set; }
        public abstract int Health { get; set; }
        public abstract int Damage { get; set; }
        public abstract HitPullView HitEffect { get; set; }

        public abstract Vector3 Move(float deltaTime);
        
        public virtual void SetCurrentPosition(Vector3 position) => transform.position = position;
        
        public void Bump(IAsteroidModel model) => OnBumped?.Invoke(model);
    }
}