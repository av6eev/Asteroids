using System.Collections.Generic;
using Game.Entities.Asteroids;
using Game.Entities.Ship;
using Global.Requirements.Base;
using Global.Rewards.Base;
using Specifications.Asteroids;
using Specifications.Asteroids.Base;
using Specifications.GameDifficulties;
using Specifications.Ships;
using Specifications.Ships.Base;
using Utilities.Enums;

namespace Utilities.Game
{
    public interface IGameSpecifications
    {
        Dictionary<ShipsTypes, IShipSpecification> Ships { get; }
        Dictionary<AsteroidsTypes, IAsteroidSpecification> Asteroids { get; }
        Dictionary<string, IReward> Rewards { get; }
        Dictionary<string, IRequirement> Requirements { get; }
        Dictionary<DifficultyStages, GameDifficultySpecification> GameDifficulties { get; }
    }
}