using System.Collections.Generic;
using Game.Asteroids;
using Game.Asteroids.Asteroid;
using Global.Pulls.Asteroids;
using Global.Pulls.ParticleSystem.Hit;
using Global.Pulls.Shots;

namespace Global.Pulls.Base
{
    public class PullsData
    {
        public ShotsPull BulletsPull { get; private set; } = new();
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