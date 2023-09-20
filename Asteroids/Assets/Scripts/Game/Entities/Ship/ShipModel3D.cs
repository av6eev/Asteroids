using Game.Entities.Ship.Base;
using Specifications.Ships;
using UnityEngine;

namespace Game.Entities.Ship
{
    public class ShipModel3D : BaseShipModel
    {
        public ShipModel3D(ShipSpecification specification) : base(specification) {}

        public ShipModel3D(IShipModel shipModel) : base(shipModel) {}
        
        public override IShipView GetViewInSpecification() => Specification.Prefab3D;
        
        public override float GetMainCoordinate() => MoveModel.Position.z;

        public override Vector3 GetPosition()
        {
            var position = base.GetPosition();
            return new Vector3(position.x, 0f, position.y);
        }
    }
}