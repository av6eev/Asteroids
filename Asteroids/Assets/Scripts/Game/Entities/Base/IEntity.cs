using UnityEngine;

namespace Game.Entities.Base
{
    public interface IEntity : IDamageable
    {
        int CurrentHealth { get; }
        int MaxHealth { get; }
        Vector3 GetPosition();
    }
}