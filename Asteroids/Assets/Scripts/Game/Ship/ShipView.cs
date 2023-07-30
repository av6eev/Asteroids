using UnityEngine;

namespace Game.Ship
{
    [RequireComponent(typeof(Rigidbody))]
    public class ShipView : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; protected set; }
    }
}