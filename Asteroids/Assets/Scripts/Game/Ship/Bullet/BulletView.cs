using System;
using Game.Asteroids.Asteroid;
using Global.Pulls.Base;
using Global.Pulls.ParticleSystem.Hit;
using UnityEngine;

namespace Game.Ship.Bullet
{
    public class BulletView : BasePullElementView
    {
        public event Action<AsteroidModel> OnBumped; 
        
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public HitPullView HitEffect { get; private set; }

        public Vector3 Move(float deltaTime)
        {
            Transform cachedTransform;
            
            (cachedTransform = transform).Translate(new Vector3(0, 0, Speed) * deltaTime);
            var position = cachedTransform.position;
            
            return new Vector3(position.x, position.y, position.z);
        }

        public void SetCurrentPosition(Vector3 position) => transform.position = position;

        public void Bump(AsteroidModel model) => OnBumped?.Invoke(model);
    }
}