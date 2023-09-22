using Game.Entities.Ship;
using Game.Entities.Ship.Base;
using Game.Factories.Ship.Base;
using Specifications.Ships;
using Specifications.Ships.Base;

namespace Game.Factories.Ship
{
    public class ShipModel2DFactory : BaseShipModelFactory
    {
        public override IShipModel Create(IShipModel baseModel) => new ShipModel2D(baseModel);
        public override IShipModel Create(IShipSpecification specification) => new ShipModel2D(specification);
    }
}