using Global.Pulls.Base;

namespace Global.Pulls.ParticleSystem.Hit
{
    public class HitsPull : BasePull<HitView>
    {
        public HitView LastActiveHit { get; set; }
    }
}