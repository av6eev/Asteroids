using System;
using Game.Entities.Asteroids.Asteroid.Base;
using Game.Entities.Bullet.Base;
using Global.Pulls.ParticleSystem.Hit;
using Global.Pulls.ParticleSystem.Hit.Base;
using UnityEngine;

namespace Game.Entities.Bullet
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class BulletView2D : MonoBehaviour, IBulletView
    {
        public event Action<IAsteroidModel> OnBumped;
        
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public HitView2D HitViewGo { get; private set; }
        public IHitView HitView => HitViewGo;
        
        public Vector3 Move(float deltaTime)
        {
            Rigidbody.velocity = new Vector2(0, Speed);
            
            return transform.position;
        }

        public void SetCurrentPosition(Vector3 position) => transform.position = position;

        public void Bump(IAsteroidModel model) => OnBumped?.Invoke(model);

        public void ChangeVisibility(bool state) => gameObject.SetActive(state);
    }
}