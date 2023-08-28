using Game.Entities.Bullet.Base;
using Global.Pulls.ParticleSystem.Hit;
using UnityEngine;

namespace Game.Entities.Bullet
{
    [RequireComponent(typeof(Rigidbody))]
    public class BulletView3D : BaseBulletView
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
        [field: SerializeField] public override float Speed { get; set; }
        [field: SerializeField] public override int Health { get; set; }
        [field: SerializeField] public override int Damage { get; set; }
        [field: SerializeField] public override HitPullView HitEffect { get; set; }

        public override Vector3 Move(float deltaTime)
        {
            var direction = new Vector3(0, 0, Speed);
            
            Rigidbody.velocity = new Vector3(direction.x, Rigidbody.velocity.y, direction.z);
            
            return transform.position;
        }
    }
}