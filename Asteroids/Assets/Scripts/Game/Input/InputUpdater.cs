using UnityEngine;
using Utilities;

namespace Game.Input
{
    public class InputUpdater : IUpdater
    {
        public void Update(GameEnvironment environment)
        {
            environment.InputModel.Update(Time.deltaTime);
        }
    }
}