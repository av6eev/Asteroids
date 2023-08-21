using Global.Pulls.Base;

namespace Global.Pulls.ParticleSystem.Hit
{
    public class HitsPull : BasePull<HitPullView>
    {
        public HitPullView LastActiveHit { get; set; }
    }
}