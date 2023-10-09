using System.Collections.Generic;
using Game.Entities.Asteroids;
using Global.Pulls.Asteroids;
using Global.Pulls.Bullets;
using Global.Pulls.ParticleSystem.Hit;

namespace Global.Pulls.Base
{
    public interface IPullsModel
    {
        BulletsPull BulletsPull { get; }
        HitsPull HitsPull { get; }
        Dictionary<AsteroidsTypes, AsteroidsPull> AsteroidsPulls { get; }

        void ClearAllData();
        void ClearAsteroidsData();
        void ClearHitsData();
        void ClearBulletsData();
    }
}