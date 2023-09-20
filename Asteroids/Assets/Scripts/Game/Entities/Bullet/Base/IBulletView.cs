using System;
using Game.Entities.Asteroids.Asteroid.Base;
using Global.Pulls.Base.PullElement;
using Global.Pulls.ParticleSystem.Hit;
using UnityEngine;

namespace Game.Entities.Bullet.Base
{
    public interface IBulletView : IPullElementView
    {
         event Action<IAsteroidModel> OnBumped;
         
         float Speed { get; }
         int Health { get; }
         int Damage { get; }
         HitView HitEffect { get; }
         
         Vector3 Move(float deltaTime);
         void SetCurrentPosition(Vector3 position);
         void Bump(IAsteroidModel model);
    }
}