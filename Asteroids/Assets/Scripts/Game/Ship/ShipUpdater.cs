using UnityEngine;
using Utilities;

namespace Game.Ship
{
    public class ShipUpdater : IUpdater
    {
        public void Update(GameEnvironment environment)
        {
            environment.ShipModel.Update(Time.deltaTime);
        }
    }
}