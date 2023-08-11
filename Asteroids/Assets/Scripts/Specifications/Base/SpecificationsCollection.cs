using System;
using Specifications.Asteroids.Collection;
using Specifications.Ships.Collection;

namespace Specifications.Base
{
    [Serializable]
    public class SpecificationsCollection
    {
        public ShipsCollectionSpecificationSo Ships;
        public AsteroidsCollectionSpecificationSo Asteroids;
    }
}