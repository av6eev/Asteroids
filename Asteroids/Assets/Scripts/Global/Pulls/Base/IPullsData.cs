using System.Collections.Generic;
using Game.Entities.Asteroids;
using Global.Pulls.Asteroids._2D;
using Global.Pulls.Asteroids._3D;
using Global.Pulls.Bullets._2D;
using Global.Pulls.Bullets._3D;
using Global.Pulls.ParticleSystem.Hit;

namespace Global.Pulls.Base
{
    public interface IPullsData
    {
        BulletsPull3D BulletsPull3D { get; }
        BulletsPull2D BulletsPull2D { get; }
        HitsPull HitsPull { get; }
        Dictionary<AsteroidsTypes, AsteroidsPull3D> AsteroidsPulls3D { get; }
        Dictionary<AsteroidsTypes, AsteroidsPull2D> AsteroidsPulls2D { get; }
    }
}