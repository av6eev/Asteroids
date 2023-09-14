using Global;
using UnityEngine;
using Utilities.Interfaces;

namespace Game.Input
{
    public class InputUpdater : IUpdater
    {
        public void Update(GlobalEnvironment environment) => environment.InputModel.Update(Time.deltaTime);
    }
}