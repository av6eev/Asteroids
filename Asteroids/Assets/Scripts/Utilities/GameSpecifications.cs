using System.Collections.Generic;
using System.Linq;
using Game.Asteroids;
using Game.Ship;
using Global.Requirements.Base;
using Global.Rewards.Base;
using Specifications.Asteroids;
using Specifications.Base;
using Specifications.GameDifficulties;
using Specifications.Ships;

namespace Utilities
{
    public class GameSpecifications
    {
        public Dictionary<ShipsTypes, ShipSpecification> Ships { get; } = new();
        public Dictionary<AsteroidsTypes, AsteroidSpecification> Asteroids { get; } = new();
        public Dictionary<string, IReward> Rewards { get; } = new();
        public Dictionary<string, IRequirement> Requirements { get; } = new();
        public Dictionary<DifficultyStages, GameDifficultySpecification> GameDifficulties { get; } = new();

        public GameSpecifications(SpecificationsCollectionSo collection)
        {
            foreach (var ship in collection.Collection.Ships.Specification.Ships.Select(element => element.Specification))
            {
                Ships.Add(ship.Type, ship);
            }

            foreach (var asteroid in collection.Collection.Asteroids.Specification.Asteroids.Select(element => element.Specification))
            {
                Asteroids.Add(asteroid.Type, asteroid);
            }
            
            foreach (var reward in collection.Collection.RewardsData.Rewards)        
            {
                Rewards.Add(reward.name, reward.Get());
            }
            
            foreach (var requirement in collection.Collection.RequirementsData.Requirements)
            {
                Requirements.Add(requirement.name, requirement.Get());
            }

            foreach (var difficulty in collection.Collection.GameDifficulties.Specification.Difficulties.Select(element => element.Specification))
            {
                GameDifficulties.Add(difficulty.Stage, difficulty);
            }
        }
    }
}