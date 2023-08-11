using UnityEngine;
using Utilities;

namespace Game.Ship.Shoot
{
    public class ShipShootUpdater : IUpdater
    {
        public void Update(GameEnvironment environment)
        {
            environment.ShipModel.ShootModel.Update(Time.deltaTime);            
        }
    }
}