using System;
using System.Collections.Generic;
using Game.Asteroids;
using Game.Asteroids.Asteroid;
using Specifications.Base;
using UnityEngine;

namespace Specifications.Asteroids
{
    [Serializable]
    public class AsteroidSpecification : ISpecification
    {
        [Header("General")] 
        public AsteroidsTypes Type;
        [Range(0f, 1f)] public float ChanceToSpawn;
        public List<AsteroidSpecificationSo> SubAsteroidsOnDestroy;
        public float Speed;

        [Header("Others")] 
        public AsteroidView Prefab;
    }
}