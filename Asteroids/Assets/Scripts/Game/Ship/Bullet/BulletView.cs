using Global.Pulls.Base;
using UnityEngine;

namespace Game.Ship.Shots
{
    public class BulletView : BasePullElementView
    {
        [field: SerializeField] public float Speed { get; private set; }

        public Vector3 Move(float deltaTime)
        {
            Transform cachedTransform;
            
            (cachedTransform = transform).Translate(new Vector3(0, 0, Speed) * deltaTime);
            var position = cachedTransform.position;
            
            return new Vector3(position.x, position.y, position.z);
        }

        public void SetCurrentPosition(Vector3 position)
        {
            transform.position = position;
        }
    }
}