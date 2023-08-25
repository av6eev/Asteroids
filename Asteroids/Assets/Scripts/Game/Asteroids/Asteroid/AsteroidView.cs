using System;
using Game.Ship.Bullet;
using Global.Pulls.Base;
using UnityEngine;
using Utilities;

namespace Game.Asteroids.Asteroid
{
    public class AsteroidView : BasePullElementView, ITriggerable
    {
        public event Action<string, BasePullElementView> OnTriggered;
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
        [field: SerializeField] public Vector3 RotationAngle { get; private set; }

        public void SetPosition(Vector3 position) => transform.position = position;
        
        public void OnTriggerEnter(Collider otherGo) => OnTriggered?.Invoke(otherGo.gameObject.tag, otherGo.gameObject.GetComponent<BulletView>());
        
        public void Rotate(float deltaTime) => transform.Rotate(RotationAngle * deltaTime);

        public Vector3 Move(Vector3 direction)
        {
            Rigidbody.velocity = new Vector3(direction.x, Rigidbody.velocity.y, direction.z);
            
            return transform.position;
        }
    }
}