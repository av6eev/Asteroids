using Game.Entities.Ship.Base;
using Specifications.Ships;
using Specifications.Ships.Base;
using UnityEngine;

namespace Game.Entities.Ship
{
    public class ShipModel2D : BaseShipModel
    {
        public ShipModel2D(IShipSpecification specification) : base(specification) {}

        public ShipModel2D(IShipModel shipModel) : base(shipModel) {}

        public override IShipView GetViewInSpecification() => Specification.ShipView2D;

        public override float GetMainCoordinate() => MoveModel.Position.y;

        public override Vector3 GetPosition()
        {
            var position = base.GetPosition();
            return new Vector3(position.x, position.z, 0f);
        }
    }
}