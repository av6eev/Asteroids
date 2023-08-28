using UnityEngine;

namespace Game.Entities.Base
{
    public interface IMovable
    {
        void UpdatePosition(Vector3 newPosition);
    }
}