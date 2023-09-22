using System;
using System.Collections.Generic;
using Specifications.Asteroids.Base;
using UnityEngine;

namespace Specifications.Asteroids
{
    [Serializable]
    public class SubAsteroidsCollection : ISubAsteroidsCollection
    {
        [field: SerializeField] public List<AsteroidSpecificationSo> SubAsteroidsOnDestroyGo { get; private set; }

        public List<IAsteroidsSpecificationSo> SubAsteroidsOnDestroy => new(SubAsteroidsOnDestroyGo);
    }
}