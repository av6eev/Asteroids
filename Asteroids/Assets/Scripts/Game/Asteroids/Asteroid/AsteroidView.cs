using Global.Pulls.Base;
using UnityEngine;

namespace Game.Asteroids.Asteroid
{
    public class AsteroidView : BasePullElementView
    {
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
    }
}