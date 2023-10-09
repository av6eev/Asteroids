using System;
using Game.Entities.Ship.Move;
using Game.Entities.Ship.Rotate;
using Game.Entities.Ship.Shoot;
using Specifications.Ships;
using Specifications.Ships.Base;
using UnityEngine;

namespace Game.Entities.Ship.Base
{
    public abstract class BaseShipModel : IShipModel
    {
        public event Action OnDamageApplied;

        public ShipMoveModel MoveModel { get; }
        public ShipShootModel ShootModel { get; }
        public ShipRotateModel RotateModel { get; }
        public IShipSpecification Specification { get; }

        public bool IsImmune { get; private set; }
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; }

        protected BaseShipModel(IShipSpecification specification)
        {
            Specification = specification;
            CurrentHealth = specification.Health;
            MaxHealth = specification.Health;
            
            ShootModel = new ShipShootModel(specification);
            MoveModel = new ShipMoveModel(specification.Speed);
            RotateModel = new ShipRotateModel();
        }

        protected BaseShipModel(IShipModel shipModel)
        {
            Specification = shipModel.Specification;
            CurrentHealth = shipModel.CurrentHealth;
            MaxHealth = shipModel.MaxHealth;
            
            ShootModel = shipModel.ShootModel;
            MoveModel = shipModel.MoveModel;
            RotateModel = shipModel.RotateModel;
        }

        public virtual void Shoot() => ShootModel.Shoot();

        public virtual void UpdateImmuneState(bool state) => IsImmune = state;

        public abstract IShipView GetViewInSpecification();

        public virtual void ApplyDamage(int damage)
        {
            if (IsImmune) return;
            
            CurrentHealth -= damage;
            OnDamageApplied?.Invoke();
        }

        public virtual Vector3 GetPosition() => MoveModel.Position;
        public abstract float GetMainCoordinate();
    }
}