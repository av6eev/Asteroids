using System;
using Game.Ship.Bullet;
using Global.Pulls.Base;
using UnityEngine;
using Utilities;

namespace Game.Asteroids.Asteroid
{
    public class AsteroidView : BasePullElementView, IColliable
    {
        public event Action<string, BasePullElementView> OnCollision;
        [field: SerializeField] public Vector3 RotationAngle { get; private set; }

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
        }

        public Vector3 Move(Vector3 multiplier)
        {
            Transform cachedTransform;
            
            (cachedTransform = transform).Translate(multiplier);
            
            return cachedTransform.position;
        }

        public void Rotate(float deltaTime)
        {
            transform.Rotate(RotationAngle * deltaTime);
        }

        public void OnCollisionEnter(Collision otherGo)
        {
            OnCollision?.Invoke(otherGo.gameObject.tag, otherGo.gameObject.GetComponent<BulletView>());           
        }
    }
}