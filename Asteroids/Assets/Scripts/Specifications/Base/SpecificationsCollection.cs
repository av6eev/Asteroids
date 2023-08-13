using System;
using Specifications.Asteroids.Collection;
using Specifications.Requirements;
using Specifications.Rewards;
using Specifications.Ships.Collection;

namespace Specifications.Base
{
    [Serializable]
    public class SpecificationsCollection
    {
        public ShipsCollectionSpecificationSo Ships;
        public AsteroidsCollectionSpecificationSo Asteroids;
        public RewardsDataSpecification RewardsData;
        public RequirementsDataSpecification RequirementsData;
    }
}