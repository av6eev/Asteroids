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
        public AsteroidView3D Prefab3D;
        public AsteroidView2D Prefab2D;
        public List<AsteroidSpecificationSo> SubAsteroidsOnDestroy;
    }
}