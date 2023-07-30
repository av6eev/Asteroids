using System.Collections.Generic;
using System.Linq;
using Specifications.Base;
using Specifications.Ships;

namespace Utilities
{
    public class GameSpecifications
    {
        public Dictionary<int, ShipSpecification> Ships { get; private set; } = new();

        public GameSpecifications(SpecificationsCollectionSo collection)
        {
            foreach (var ship in collection.Collection.Ships.Specification.Ships.Select(element => element.Specification))
            {
                Ships.Add(ship.Id, ship);
            }
        }
    }
}