using Global;
using UnityEngine;
using Utilities.Interfaces;

namespace Game.Entities.Asteroids
{
    public class AsteroidsUpdater : IUpdater
    {
        public void Update(GlobalEnvironment environment) => environment.AsteroidsModel.Update(Time.deltaTime);
    }
}