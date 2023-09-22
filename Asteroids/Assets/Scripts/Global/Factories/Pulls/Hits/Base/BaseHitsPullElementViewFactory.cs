using Global.Pulls.ParticleSystem.Hit;
using Global.Pulls.ParticleSystem.Hit.Base;

namespace Global.Factories.Pulls.Hits.Base
{
    public abstract class BaseHitsPullElementViewFactory
    {
        public abstract IHitView Get(GlobalEnvironment environment);
    }
}