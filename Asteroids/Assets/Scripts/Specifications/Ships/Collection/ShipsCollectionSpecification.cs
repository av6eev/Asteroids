using System;
using System.Collections.Generic;
using Specifications.Base;

namespace Specifications.Ships.Collection
{
    [Serializable]
    public class ShipsCollectionSpecification : ISpecification
    {
        public List<ShipSpecificationSo> Ships;
    }
}