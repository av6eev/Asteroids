﻿using System;
using Game.Entities.Base;
using Game.Entities.Ship.Move;
using Game.Entities.Ship.Rotate;
using Game.Entities.Ship.Shoot;
using Specifications.Ships;
using Specifications.Ships.Base;

namespace Game.Entities.Ship.Base
{
    public interface IShipModel : IEntity 
    {
        public event Action OnDamageApplied;
        
        ShipMoveModel MoveModel { get; }
        ShipShootModel ShootModel { get; }
        ShipRotateModel RotateModel { get; }
        IShipSpecification Specification { get; }
        public bool IsImmune { get; }

        void Shoot();
        void UpdateImmuneState(bool state);
        IShipView GetViewInSpecification();
        float GetMainCoordinate();
    }
}