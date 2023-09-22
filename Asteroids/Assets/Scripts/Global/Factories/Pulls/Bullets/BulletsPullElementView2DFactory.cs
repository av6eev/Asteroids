using Game.Entities.Bullet.Base;
using Global.Base;
using Global.Factories.Pulls.Bullets.Base;

namespace Global.Factories.Pulls.Bullets
{
    public class BulletsPullElementView2DFactory : BaseBulletsPullElementViewFactory
    {
        public override IBulletView Get(IGlobalEnvironment environment) => environment.ShipModel.Specification.BulletView2D;
    }
}