using System.Collections.Generic;
using Game.Asteroids;
using Global.Pulls.Asteroids._2D;
using Global.Pulls.Asteroids._3D;
using Global.Pulls.Bullets._2D;
using Global.Pulls.Bullets._3D;
using Global.Pulls.ParticleSystem.Hit;

namespace Global.Pulls.Base
{
    public class PullsData
    {
        public BulletsPull3D BulletsPull3D { get; private set; } = new();
        public BulletsPull2D BulletsPull2D { get; private set; } = new();
        public HitsPull HitsPull { get; private set; } = new();

        public Dictionary<AsteroidsTypes, AsteroidsPull3D> AsteroidsPulls3D { get; private set; } = new()
        {
            { AsteroidsTypes.Small, new AsteroidsPull3D() },
            { AsteroidsTypes.Medium, new AsteroidsPull3D() },
            { AsteroidsTypes.Big, new AsteroidsPull3D() },
            { AsteroidsTypes.Fire, new AsteroidsPull3D() }
        };

        public Dictionary<AsteroidsTypes, AsteroidsPull2D> AsteroidsPulls2D { get; private set; } = new()
        {
            { AsteroidsTypes.Small, new AsteroidsPull2D() },
            { AsteroidsTypes.Medium, new AsteroidsPull2D() },
            { AsteroidsTypes.Big, new AsteroidsPull2D() },
            { AsteroidsTypes.Fire, new AsteroidsPull2D() }
        };
    }
}