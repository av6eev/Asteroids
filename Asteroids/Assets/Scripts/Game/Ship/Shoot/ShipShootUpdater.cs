using UnityEngine;
using Utilities;

namespace Game.Ship.Shoot
{
    public class ShipShootUpdater : IUpdater
    {
        public void Update(GlobalEnvironment environment)
        {
            environment.ShipModel.ShootModel.Update(Time.deltaTime);            
        }
    }
}