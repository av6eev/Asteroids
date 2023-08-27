using UnityEngine;

namespace Game.Ship.Base
{
    public interface IShipView
    {
        Vector3 Move(Vector3 direction);
        void EnableImmunity();
        void Rotate(float rotation);
        void ResetPosition(Vector3 shipPosition);
        Quaternion ResetRotation();
    }
}