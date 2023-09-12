using Game.Entities.Bullet;
using Game.Entities.Bullet.Base;
using Game.Factories.Bullet.Base;
using UnityEngine;

namespace Game.Factories.Bullet
{
    public class BulletModel3DFactory : BaseBulletModelFactory
    {
        public override IBulletModel Create(Vector3 position, int health, int damage) => new BulletModel3D(position, health, damage);
    }
}