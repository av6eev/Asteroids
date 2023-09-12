using Game.Entities.Bullet.Base;
using UnityEngine;

namespace Game.Factories.Bullet.Base
{
    public abstract class BaseBulletModelFactory
    {
        public abstract IBulletModel Create(Vector3 position, int health, int damage);
    }
}