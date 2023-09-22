using System;
using Game.Entities.Asteroids;
using Game.Entities.Asteroids.Asteroid;
using Game.Entities.Asteroids.Asteroid.Base;
using Specifications.Asteroids.Base;
using UnityEngine;

namespace Specifications.Asteroids
{
    [Serializable]
    public class AsteroidSpecification : IAsteroidSpecification
    {
        [field: Header("General")] 
        [field: SerializeField] public AsteroidsTypes Type { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] [field: Range(0f, 1f)] public float ChanceToSpawn { get; private set; }

        [field: Header("Others")] 
        [field: SerializeField] public AsteroidView3D Prefab3D { get; private set; }
        [field: SerializeField] public AsteroidView2D Prefab2D { get; private set; }
        [field: SerializeField] public SubAsteroidsCollection SubAsteroidsOnDestroy { get; private set; }

        public IAsteroidView AsteroidView3D => Prefab3D;
        public IAsteroidView AsteroidView2D => Prefab2D;
        public ISubAsteroidsCollection SubAsteroidsCollection => SubAsteroidsOnDestroy;
    }
}