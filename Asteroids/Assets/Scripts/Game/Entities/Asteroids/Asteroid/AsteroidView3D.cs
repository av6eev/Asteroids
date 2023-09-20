using System;
using Game.Entities.Asteroids.Asteroid.Base;
using Game.Entities.Bullet.Base;
using Global.Pulls.Base.PullElement;
using UnityEngine;
using Utilities.Interfaces;

namespace Game.Entities.Asteroids.Asteroid
{
    [RequireComponent(typeof(Rigidbody))]
    public class AsteroidView3D : MonoBehaviour, IAsteroidView, ITriggerable3D
    {
        public event Action<string, IPullElementView> OnTriggered;
        
        [field: SerializeField] public Rigidbody Rigidbody { get; private set; }
        [field: SerializeField] public Vector3 RotationAngle { get; private set; }

        public void OnTriggerEnter(Collider other) => OnTriggered?.Invoke(other.gameObject.tag, other.gameObject.GetComponent<IBulletView>());
        
        public void SetPosition(Vector3 position) => transform.position = position;

        public void Rotate(float deltaTime) => transform.Rotate(RotationAngle * deltaTime);

        public void ChangeVisibility(bool state) => gameObject.SetActive(state);

        public Vector3 Move(Vector3 direction)
        {
            Rigidbody.velocity = new Vector3(direction.x, Rigidbody.velocity.y, direction.z);
            
            return transform.position;
        }
    }
}