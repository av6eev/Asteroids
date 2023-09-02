﻿using Global;
using UnityEngine;
using Utilities;
using Utilities.Interfaces;

namespace Game.Entities.Ship.Move
{
    public class ShipMoveUpdater : IUpdater
    {
        public void Update(GlobalEnvironment environment) => environment.ShipModel.MoveModel.Update(Time.deltaTime);
    }
}