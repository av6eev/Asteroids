using System;
using System.Collections.Generic;
using Specifications.Base;

namespace Specifications.Asteroids.Collection
{
    [Serializable]
    public class AsteroidsCollectionSpecification : ISpecification
    {
        public List<AsteroidSpecificationSo> Asteroids;
    }
}