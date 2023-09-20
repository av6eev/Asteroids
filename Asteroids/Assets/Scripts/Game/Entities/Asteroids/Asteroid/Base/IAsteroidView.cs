using Global.Pulls.Base.PullElement;
using UnityEngine;
using Utilities.Interfaces;

namespace Game.Entities.Asteroids.Asteroid.Base
{
    public interface IAsteroidView : IPullElementView, ITriggerable
    {
        public Vector3 RotationAngle { get; }

        public void SetPosition(Vector3 position);
        public void Rotate(float deltaTime);
        public Vector3 Move(Vector3 direction);
    }
}