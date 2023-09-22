using Global;
using Global.Base;
using UnityEngine;
using Utilities.Interfaces;

namespace Game.Entities.Ship.Rotate
{
    public class ShipRotateUpdater : IUpdater
    {
        public void Update(IGlobalEnvironment environment) => environment.ShipModel.RotateModel.Update(Time.deltaTime);
    }
}