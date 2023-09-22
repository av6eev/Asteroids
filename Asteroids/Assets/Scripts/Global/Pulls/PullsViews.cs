using Global.Pulls.Asteroids;
using Global.Pulls.Base;
using Global.Pulls.Bullets;
using Global.Pulls.ParticleSystem.Hit;
using Global.Pulls.ParticleSystem.Hit.Base;
using UnityEngine;

namespace Global.Pulls
{
    public class PullsViews : MonoBehaviour, IPullsViews
    {
        [field: SerializeField] public AsteroidsPullView SmallAsteroidsPullViewGo { get; private set; }
        [field: SerializeField] public AsteroidsPullView MediumAsteroidsPullViewGo { get; private set; }
        [field: SerializeField] public AsteroidsPullView BigAsteroidsPullViewGo { get; private set; }
        [field: SerializeField] public AsteroidsPullView FireAsteroidsPullViewGo { get; private set; }
        [field: SerializeField] public BulletsPullView BulletsPullViewGo { get; private set; }
        [field: SerializeField] public HitsPullView HitsPullViewGo { get; private set; }

        public IAsteroidsPullView SmallAsteroidsPullView => SmallAsteroidsPullViewGo;
        public IAsteroidsPullView MediumAsteroidsPullView => MediumAsteroidsPullViewGo;
        public IAsteroidsPullView BigAsteroidsPullView => BigAsteroidsPullViewGo;
        public IAsteroidsPullView FireAsteroidsPullView => FireAsteroidsPullViewGo;
        public IBulletsPullView BulletsPullView => BulletsPullViewGo;
        public IHitsPullView HitsPullView => HitsPullViewGo;
    }
}