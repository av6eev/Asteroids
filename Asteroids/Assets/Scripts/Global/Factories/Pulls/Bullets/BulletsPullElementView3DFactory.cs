using Game.Entities.Bullet.Base;
using Global.Factories.Pulls.Bullets.Base;

namespace Global.Factories.Pulls.Bullets
{
    public class BulletsPullElementView3DFactory : BaseBulletsPullElementViewFactory
    {
        public override IBulletView Get(GlobalEnvironment environment) => environment.ShipModel.Specification.BulletPrefab3D;
    }
}