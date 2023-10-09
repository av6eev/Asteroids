using Global;
using Global.Base;
using UnityEngine;
using Utilities.Interfaces;

namespace Game.Entities.Ship.Move
{
    public class ShipMoveUpdater : IUpdater
    {
        public void Update(IGlobalEnvironment environment) => environment.ShipModel.MoveModel.Update(Time.deltaTime);
    }
}