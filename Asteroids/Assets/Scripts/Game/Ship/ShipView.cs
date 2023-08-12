using UnityEngine;

namespace Game.Ship
{
    public class ShipView : MonoBehaviour
    {
        public Vector3 Move(Vector3 direction)
        {
            Transform cachedTransform;
            
            (cachedTransform = transform).Translate(direction);
            
            return cachedTransform.position;
        }

        public void ResetPosition(Vector3 shipPosition)
        {
            transform.position = shipPosition;
        }

        public void EnableImmunity()
        {
        }
    }
}