using System.Collections.Generic;
using Game.Entities.Asteroids;
using Global.Pulls.Asteroids;
using Global.Pulls.Base;
using Global.Pulls.Bullets;
using Global.Pulls.ParticleSystem.Hit;

namespace Global.Pulls
{
    public class PullsModel : IPullsModel
    {
        public BulletsPull BulletsPull { get; } = new();
        public HitsPull HitsPull { get; } = new();
        public Dictionary<AsteroidsTypes, AsteroidsPull> AsteroidsPulls { get; } = new()
        {
            { AsteroidsTypes.Small, new AsteroidsPull() },
            { AsteroidsTypes.Medium, new AsteroidsPull() },
            { AsteroidsTypes.Big, new AsteroidsPull() },
            { AsteroidsTypes.Fire, new AsteroidsPull() }
        };

        public void ClearAllData()
        {
            ClearAsteroidsData();
            ClearBulletsData();
            ClearHitsData();
        }

        public void ClearAsteroidsData()
        {
            foreach (var pull in AsteroidsPulls)
            {
                pull.Value.Dispose();
            }
        }

        public void ClearHitsData() => HitsPull.Dispose();

        public void ClearBulletsData() => BulletsPull.Dispose();
    }
}