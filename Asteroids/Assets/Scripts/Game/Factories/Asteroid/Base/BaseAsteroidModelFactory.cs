﻿using Game.Entities.Asteroids.Asteroid.Base;
using Specifications.Asteroids;
using Specifications.Asteroids.Base;

namespace Game.Factories.Asteroid.Base
{
    public abstract class BaseAsteroidModelFactory
    {
        public abstract IAsteroidModel Create(IAsteroidModel baseModel);
        public abstract IAsteroidModel Create(IAsteroidSpecification specification, float speedShift);
    }
}