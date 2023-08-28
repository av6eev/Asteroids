using Game.Entities.Asteroids.Asteroid.Base;
using UnityEngine;

namespace Game.Entities.Asteroids.Asteroid
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class AsteroidView2D : BaseAsteroidView
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public override Vector3 RotationAngle { get; set; }
        
        public override Vector3 Move(Vector3 direction)
        {
            Rigidbody.velocity = new Vector2(direction.x, direction.z);
            
            return transform.position;
        }
    }
}