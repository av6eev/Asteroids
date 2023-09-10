using System;
using Game.Entities.Base;
using Specifications.Asteroids;
using UnityEngine;
using Utilities.Game;
using Utilities.Interfaces;

namespace Game.Entities.Asteroids.Asteroid.Base
{
    public interface IAsteroidModel : IEntity, IMovable, IUpdatable
    {
        public event Action OnDestroy;
        AsteroidSpecification Specification { get; }
        Vector3 Direction { get; }
        Vector3 Position { get; }
        float Speed { get; }

        bool CheckIntersects(GameZoneLimits limits);
        void SetPosition(float horizontal, float forward);
        Tuple<float, float> GetPositionWithOffset(float horizontal, float forward);
    }
}