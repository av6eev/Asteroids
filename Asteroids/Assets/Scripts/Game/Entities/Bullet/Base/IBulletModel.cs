using System;
using Game.Entities.Base;
using UnityEngine;
using Utilities.Game;
using Utilities.Interfaces;

namespace Game.Entities.Bullet.Base
{
    public interface IBulletModel : IEntity, IMovable, IUpdatable
    {
        public event Action OnDestroy;

        Vector3 Position { get; }
        int Damage { get; }
        bool CheckIntersects(GameZoneLimits zoneLimits);
    }
}