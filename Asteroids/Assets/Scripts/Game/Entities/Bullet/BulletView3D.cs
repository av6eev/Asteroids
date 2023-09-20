using System;
using Game.Entities.Asteroids.Asteroid.Base;
using Game.Entities.Bullet.Base;
using Global.Pulls.ParticleSystem.Hit;
using UnityEngine;

namespace Game.Entities.Bullet
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletView3D : MonoBehaviour, IBulletView
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
        public event Action<IAsteroidModel> OnBumped;
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public HitView HitEffect { get; private set; }

        public Vector3 Move(float deltaTime)
        {
            var direction = new Vector3(0, 0, Speed);
            
            Rigidbody.velocity = new Vector3(direction.x, Rigidbody.velocity.y, direction.z);
            
            return transform.position;
        }

        public void SetCurrentPosition(Vector3 position) => transform.position = position;

        public void Bump(IAsteroidModel model) => OnBumped?.Invoke(model);

        public void ChangeVisibility(bool state) => gameObject.SetActive(state);
    }
}