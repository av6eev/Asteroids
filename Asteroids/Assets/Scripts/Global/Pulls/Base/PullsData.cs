using System.Collections.Generic;
using Game.Asteroids;
using Global.Pulls.Asteroids;
using Global.Pulls.Bullets;
using Global.Pulls.ParticleSystem.Hit;

namespace Global.Pulls.Base
{
    public class PullsData
    {
        public BulletsPull BulletsPull { get; private set; } = new();
        public HitsPull HitsPull { get; private set; } = new();
        
        public Dictionary<AsteroidsTypes, AsteroidsPull> AsteroidsPulls { get; private set; } = new()
        {
            { AsteroidsTypes.Small, new AsteroidsPull() },
            { AsteroidsTypes.Medium, new AsteroidsPull() },
            { AsteroidsTypes.Big, new AsteroidsPull() },
            { AsteroidsTypes.Fire, new AsteroidsPull() },
        };
    }
}