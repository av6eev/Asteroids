using UnityEngine;

namespace Utilities.Interfaces
{
    public interface ITriggerable3D : ITriggerable
    {
        void OnTriggerEnter(Collider other);
    }
}