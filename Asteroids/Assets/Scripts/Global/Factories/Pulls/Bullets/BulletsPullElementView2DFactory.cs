using Game.Entities.Bullet.Base;
using Global.Factories.Pulls.Bullets.Base;

namespace Global.Factories.Pulls.Bullets
{
    public class BulletsPullElementView2DFactory : BaseBulletsPullElementViewFactory
    {
        public override IBulletView Get(GlobalEnvironment environment) => environment.ShipModel.Specification.BulletPrefab2D;
    }
}