using UnityEngine;

namespace Game.Entities.Ship.Base
{
    public abstract class BaseShipView : MonoBehaviour
    {
        public abstract Transform BulletSpawnPoint { get; protected set; }
        public abstract Vector3 Move(Vector3 direction);
        
        public abstract void EnableImmunity();

        public virtual void ResetPosition(Vector3 shipPosition) => transform.position = shipPosition;
        
        public virtual void Rotate(float rotation) => transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, rotation), .5f);

        public virtual Quaternion ResetRotation() => transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), .05f);
    }
}