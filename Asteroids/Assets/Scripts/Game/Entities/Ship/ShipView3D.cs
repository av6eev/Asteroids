using Game.Entities.Ship.Base;
using UnityEngine;

namespace Game.Entities.Ship
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(MeshCollider))]
    public class ShipView3D : MonoBehaviour, IShipView
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
        [field: SerializeField] public Transform BulletSpawnPoint { get; private set; }
        
        public Vector3 Move(Vector3 direction)
        {
            Rigidbody.velocity = new Vector3(direction.x, Rigidbody.velocity.y, direction.z);
            
            return transform.position; 
        }

        public void ResetPosition(Vector3 shipPosition) => transform.position = shipPosition;

        public void Rotate(float rotation) => transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, rotation), .5f);

        public Quaternion ResetRotation() => transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), .05f);
        
        public void EnableImmunity() {}
    }
}