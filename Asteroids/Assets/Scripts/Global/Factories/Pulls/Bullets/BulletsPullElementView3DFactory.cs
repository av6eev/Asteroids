using Game.Entities.Bullet.Base;
using Global.Factories.Pulls.Bullets.Base;

namespace Global.Factories.Pulls.Bullets
{
    public class BulletsPullElementView3DFactory : BaseBulletsPullElementViewFactory
    {
        public override IBulletView Get(IGlobalEnvironment environment) => environment.ShipModel.Specification.BulletView3D;
    }
}