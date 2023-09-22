using Global.Factories.Pulls.Hits.Base;
using Global.Pulls.ParticleSystem.Hit.Base;

namespace Global.Factories.Pulls.Hits
{
    public class HitsPullElementView2DFactory : BaseHitsPullElementViewFactory
    {
        public override IHitView Get(IGlobalEnvironment environment) => environment.ShipModel.Specification.BulletView2D.HitView;
    }
}