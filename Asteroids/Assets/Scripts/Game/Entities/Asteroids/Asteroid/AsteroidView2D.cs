using System;
using Game.Entities.Asteroids.Asteroid.Base;
using Game.Entities.Bullet.Base;
using Global.Pulls.Base.PullElement;
using Unity.VisualScripting;
using UnityEngine;
using Utilities.Interfaces;

namespace Game.Entities.Asteroids.Asteroid
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class AsteroidView2D : MonoBehaviour, IAsteroidView, ITriggerable2D
    {
        public event Action<string, IPullElementView> OnTriggered;

        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
        [field: SerializeField] public Vector3 RotationAngle { get; private set; }

        public Vector3 Move(Vector3 direction)
        {
            Rigidbody.velocity = new Vector2(direction.x, direction.z);
            
            return transform.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            throw new NotImplementedException();
        }
        
        public void OnTriggerEnter2D(Collider2D other) => OnTriggered?.Invoke(other.gameObject.tag, other.gameObject.GetComponent<IBulletView>());

        public void SetPosition(Vector3 position) => transform.position = position;

        public void Rotate(float deltaTime) => transform.Rotate(RotationAngle * deltaTime);

        public void ChangeVisibility(bool state) => gameObject.SetActive(state);
    }
}