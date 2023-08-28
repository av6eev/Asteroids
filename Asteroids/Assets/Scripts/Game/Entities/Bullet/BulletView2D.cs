using Game.Entities.Bullet.Base;
using Global.Pulls.ParticleSystem.Hit;
using UnityEngine;

namespace Game.Entities.Bullet
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class BulletView2D : BaseBulletView
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public override float Speed { get; set; }
        [field: SerializeField] public override int Health { get; set; }
        [field: SerializeField] public override int Damage { get; set; }
        [field: SerializeField] public override HitPullView HitEffect { get; set; }
        
        public override Vector3 Move(float deltaTime)
        {
            Rigidbody.velocity = new Vector2(0, Speed);
            
            return transform.position;
        }
    }
}