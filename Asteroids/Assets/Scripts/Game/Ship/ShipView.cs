using UnityEngine;

namespace Game.Ship
{
    [RequireComponent(typeof(Rigidbody))]
    public class ShipView : MonoBehaviour
    {
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }

        public Vector3 Move(Vector3 multiplier)
        {
            Transform cachedTransform;
            
            (cachedTransform = transform).Translate(multiplier);
            
            return cachedTransform.position;
        }

        public void ResetPosition(Vector3 shipPosition)
        {
            transform.position = shipPosition;
        }
    }
}