using Global;
using UnityEngine;
using Utilities;

namespace Game.Ship.Rotate
{
    public class ShipRotateUpdater : IUpdater
    {
        public void Update(GlobalEnvironment environment)
        {
            environment.ShipModel.RotateModel.Update(Time.deltaTime);
        }
    }
}