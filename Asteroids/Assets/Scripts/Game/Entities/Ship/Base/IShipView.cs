using UnityEngine;

namespace Game.Entities.Ship.Base
{
    public interface IShipView
    {
        public Transform BulletSpawnPoint { get; }
        
        public Vector3 Move(Vector3 direction);
        public void EnableImmunity();
        public void ResetPosition(Vector3 shipPosition);
        public Quaternion ResetRotation();
        public void Rotate(float rotation);
    }
}