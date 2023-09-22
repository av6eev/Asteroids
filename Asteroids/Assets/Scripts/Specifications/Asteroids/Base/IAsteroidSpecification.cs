using Game.Entities.Asteroids;
using Game.Entities.Asteroids.Asteroid.Base;
using Specifications.Base;

namespace Specifications.Asteroids.Base
{
    public interface IAsteroidSpecification : ISpecification
    {
        AsteroidsTypes Type { get; }
        int Health { get; }
        float Speed { get; }
        float ChanceToSpawn { get; }
        IAsteroidView AsteroidView3D { get; }
        IAsteroidView AsteroidView2D { get; }
        ISubAsteroidsCollection SubAsteroidsCollection { get; }
    }
}