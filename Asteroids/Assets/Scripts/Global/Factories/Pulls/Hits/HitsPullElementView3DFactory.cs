using Global.Factories.Pulls.Hits.Base;
using Global.Pulls.ParticleSystem.Hit.Base;

namespace Global.Factories.Pulls.Hits
{
    public class HitsPullElementView3DFactory : BaseHitsPullElementViewFactory
    {
        public override IHitView Get(GlobalEnvironment environment) => environment.ShipModel.Specification.BulletPrefab3D.HitView;
    }
}