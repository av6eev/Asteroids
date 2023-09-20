using UnityEngine;

namespace Utilities.Interfaces
{
    public interface ITriggerable2D : ITriggerable
    {
        void OnTriggerEnter2D(Collider2D other);
    }
}