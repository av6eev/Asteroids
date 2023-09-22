using Global;
using UnityEngine;
using Utilities.Interfaces;

namespace Game.Entities.Ship.Shoot
{
    public class ShipShootUpdater : IUpdater
    {
        public void Update(IGlobalEnvironment environment) => environment.ShipModel.ShootModel.Update(Time.deltaTime);
    }
}