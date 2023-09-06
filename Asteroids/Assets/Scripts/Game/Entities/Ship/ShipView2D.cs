using Game.Entities.Ship.Base;
using UnityEngine;

namespace Game.Entities.Ship
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class ShipView2D : BaseShipView
    {
        [field: SerializeField] public Rigidbody2D Rigidbody { get; set; }

        public override Vector3 Move(Vector3 direction)
        {
            Rigidbody.velocity = new Vector2(direction.x, direction.z);
            
            return transform.position; 
        }

        public override void EnableImmunity() {}
    }
}