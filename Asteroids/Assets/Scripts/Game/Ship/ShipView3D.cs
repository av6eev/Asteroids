using Game.Ship.Base;
using UnityEngine;

namespace Game.Ship
{
    [RequireComponent(typeof(Rigidbody))]
    public class ShipView3D : BaseShipView
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; set; }

        public override Vector3 Move(Vector3 direction)
        {
            Rigidbody.velocity = new Vector3(direction.x, Rigidbody.velocity.y, direction.z);
            
            return transform.position; 
        }

        public override void EnableImmunity() {}
    }
}