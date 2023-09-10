using System;
using Game.Entities.Bullet.Base;
using Global.Pulls.Base;
using UnityEngine;
using Utilities.Interfaces;

namespace Game.Entities.Asteroids.Asteroid.Base
{
    public abstract class BaseAsteroidView : BasePullElementView, ITriggerable
    {
        public event Action<string, BasePullElementView> OnTriggered;
        public abstract Vector3 RotationAngle { get; set; }

        public void OnTriggerEnter(Collider otherGo) => OnTriggered?.Invoke(otherGo.gameObject.tag, otherGo.gameObject.GetComponent<BaseBulletView>());
        public void OnTriggerEnter2D(Collider2D otherGo) => OnTriggered?.Invoke(otherGo.gameObject.tag, otherGo.gameObject.GetComponent<BaseBulletView>());
        
        public virtual void SetPosition(Vector3 position) => transform.position = position;
        
        public virtual void Rotate(float deltaTime) => transform.Rotate(RotationAngle * deltaTime);

        public abstract Vector3 Move(Vector3 direction);
    }
}