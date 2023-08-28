using Game.Entities.Asteroids.Asteroid.Base;
using UnityEngine;

namespace Game.Entities.Asteroids.Asteroid
{
    [RequireComponent(typeof(Rigidbody))]
    public class AsteroidView3D : BaseAsteroidView
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
        [field: SerializeField] public override Vector3 RotationAngle { get; set; }

        public override Vector3 Move(Vector3 direction)
        {
            Rigidbody.velocity = new Vector3(direction.x, Rigidbody.velocity.y, direction.z);
            
            return transform.position;
        }
    }
}