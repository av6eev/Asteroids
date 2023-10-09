using Global;
using Global.Base;
using UnityEngine;
using Utilities.Interfaces;

namespace Game.Input
{
    public class InputUpdater : IUpdater
    {
        public void Update(IGlobalEnvironment environment) => environment.InputModel.Update(Time.deltaTime);
    }
}