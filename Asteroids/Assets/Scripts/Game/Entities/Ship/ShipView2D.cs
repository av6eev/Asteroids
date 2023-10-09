using Game.Entities.Ship.Base;
using UnityEngine;

namespace Game.Entities.Ship
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class ShipView2D : MonoBehaviour, IShipView
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public Transform BulletSpawnPoint { get; private set; }

        public Vector3 Move(Vector3 direction)
        {
            Rigidbody.velocity = new Vector2(direction.x, direction.z);
            
            return transform.position; 
        }

        public void ResetPosition(Vector3 shipPosition) => transform.position = shipPosition;

        public void Rotate(float rotation) => transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, rotation), .5f);

        public Quaternion ResetRotation() => transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), .05f);
        
        public void EnableImmunity() {}
    }
}