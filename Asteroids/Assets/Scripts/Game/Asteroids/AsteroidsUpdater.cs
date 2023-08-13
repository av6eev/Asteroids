using UnityEngine;
using Utilities;

namespace Game.Asteroids
{
    public class AsteroidsUpdater : IUpdater
    {
        public void Update(GlobalEnvironment environment)
        {
            environment.AsteroidsModel.Update(Time.deltaTime);
        }
    }
}