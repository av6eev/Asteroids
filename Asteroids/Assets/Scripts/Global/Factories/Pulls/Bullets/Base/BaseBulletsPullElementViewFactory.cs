using Game.Entities.Bullet.Base;

namespace Global.Factories.Pulls.Bullets.Base
{
    public abstract class BaseBulletsPullElementViewFactory
    {
        public abstract IBulletView Get(GlobalEnvironment environment);
    }
}