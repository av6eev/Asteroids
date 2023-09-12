using Game.Entities.Bullet;
using Game.Entities.Bullet.Base;
using Game.Factories.Bullet.Base;
using UnityEngine;

namespace Game.Factories.Bullet
{
    public class BulletModel2DFactory : BaseBulletModelFactory
    {
        public override IBulletModel Create(Vector3 position, int health, int damage) => new BulletModel2D(position, health, damage);
    }
}