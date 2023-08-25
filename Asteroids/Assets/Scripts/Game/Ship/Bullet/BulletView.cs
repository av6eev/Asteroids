using System;
using Game.Asteroids.Asteroid;
using Global.Pulls.Base;
using Global.Pulls.ParticleSystem.Hit;
using UnityEngine;

namespace Game.Ship.Bullet
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletView : BasePullElementView
    {
        public event Action<AsteroidModel> OnBumped; 
        
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public HitPullView HitEffect { get; private set; }

        public Vector3 Move(float deltaTime)
        {
            var direction = new Vector3(0, 0, Speed);
            
            Rigidbody.velocity = new Vector3(direction.x, Rigidbody.velocity.y, direction.z);
            
            return transform.position;
        }

        public void SetCurrentPosition(Vector3 position) => transform.position = position;

        public void Bump(AsteroidModel model) => OnBumped?.Invoke(model);
    }
}