using Global.Pulls.Base;
using Global.Pulls.ParticleSystem.Hit.Base;

namespace Global.Pulls.ParticleSystem.Hit
{
    public class HitsPull : BasePull<IHitView>
    {
        public IHitView LastActiveHit { get; set; }

        public override void Dispose()
        {
            base.Dispose();
            
            LastActiveHit = null;
        }
    }
}