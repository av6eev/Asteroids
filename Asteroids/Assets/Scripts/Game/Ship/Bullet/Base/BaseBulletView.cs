using System;
using Game.Asteroids.Asteroid;
using Global.Pulls.Base;
using Global.Pulls.ParticleSystem.Hit;
using UnityEngine;

namespace Game.Ship.Bullet.Base
{
    public abstract class BaseBulletView : BasePullElementView
    {
        public event Action<AsteroidModel> OnBumped; 
        
        public abstract float Speed { get; set; }
        public abstract int Health { get; set; }
        public abstract int Damage { get; set; }
        public abstract HitPullView HitEffect { get; set; }

        public abstract Vector3 Move(float deltaTime);
        
        public virtual void SetCurrentPosition(Vector3 position) => transform.position = position;
        
        public void Bump(AsteroidModel model) => OnBumped?.Invoke(model);
    }
}