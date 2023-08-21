using Global;
using UnityEngine;
using Utilities;

namespace Game.Ship.Move
{
    public class ShipMoveUpdater : IUpdater
    {
        public void Update(GlobalEnvironment environment) => environment.ShipModel.MoveModel.Update(Time.deltaTime);
    }
}