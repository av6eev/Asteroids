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
        public int Health;
        public float Speed;
        [Range(0f, 1f)] public float ChanceToSpawn;

        [Header("Others")] 
        public AsteroidView Prefab;
        public List<AsteroidSpecificationSo> SubAsteroidsOnDestroy;
    }
}