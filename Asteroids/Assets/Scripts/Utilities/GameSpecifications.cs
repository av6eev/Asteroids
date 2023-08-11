using System.Collections.Generic;
using System.Linq;
using Game.Asteroids;
using Game.Asteroids.Asteroid;
using Specifications.Asteroids;
using Specifications.Base;
using Specifications.Ships;

namespace Utilities
{
    public class GameSpecifications
    {
        public Dictionary<int, ShipSpecification> Ships { get; } = new();
        public Dictionary<AsteroidsTypes, AsteroidSpecification> Asteroids { get; } = new();

        public GameSpecifications(SpecificationsCollectionSo collection)
        {
            foreach (var ship in collection.Collection.Ships.Specification.Ships.Select(element => element.Specification))
            {
                Ships.Add(ship.Id, ship);
            }

            foreach (var asteroid in collection.Collection.Asteroids.Specification.Asteroids.Select(element => element.Specification))
            {
                Asteroids.Add(asteroid.Type, asteroid);
            }
        }
    }
}