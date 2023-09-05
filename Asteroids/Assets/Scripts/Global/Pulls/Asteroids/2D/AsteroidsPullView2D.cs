﻿using Game.Entities.Asteroids;
using Game.Entities.Asteroids.Asteroid;
using Global.Pulls.Base;
using UnityEngine;

namespace Global.Pulls.Asteroids._2D
{
    public class AsteroidsPullView2D : BasePullView<AsteroidView2D>
    {
        [field: SerializeField] public AsteroidsTypes Type { get; private set; }
    }
}