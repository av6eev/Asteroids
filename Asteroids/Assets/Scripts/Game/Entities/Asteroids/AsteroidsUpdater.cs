using Global;
using UnityEngine;
using Utilities.Interfaces;

namespace Game.Entities.Asteroids
{
    public class AsteroidsUpdater : IUpdater
    {
        public void Update(IGlobalEnvironment environment) => environment.AsteroidsModel.Update(Time.deltaTime);
    }
}