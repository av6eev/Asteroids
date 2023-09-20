using System.Collections.Generic;
using Game.Entities.Asteroids;
using Global.Pulls.Asteroids._2D;
using Global.Pulls.Asteroids._3D;
using Global.Pulls.Base.PullData;
using Global.Pulls.Bullets._2D;
using Global.Pulls.Bullets._3D;
using Global.Pulls.ParticleSystem.Hit;

namespace Global.Pulls
{
    public class PullsData : IPullsData
    {
        public BulletsPull3D BulletsPull3D { get; } = new();
        public BulletsPull2D BulletsPull2D { get; } = new();
        public HitsPull HitsPull { get; } = new();
        public Dictionary<AsteroidsTypes, AsteroidsPull3D> AsteroidsPulls3D { get; } = new()
        {
            { AsteroidsTypes.Small, new AsteroidsPull3D() },
            { AsteroidsTypes.Medium, new AsteroidsPull3D() },
            { AsteroidsTypes.Big, new AsteroidsPull3D() },
            { AsteroidsTypes.Fire, new AsteroidsPull3D() }
        };
        public Dictionary<AsteroidsTypes, AsteroidsPull2D> AsteroidsPulls2D { get; } = new()
        {
            { AsteroidsTypes.Small, new AsteroidsPull2D() },
            { AsteroidsTypes.Medium, new AsteroidsPull2D() },
            { AsteroidsTypes.Big, new AsteroidsPull2D() },
            { AsteroidsTypes.Fire, new AsteroidsPull2D() }
        };
    }
}