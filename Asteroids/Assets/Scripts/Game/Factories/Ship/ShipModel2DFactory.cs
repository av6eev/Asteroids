using Game.Entities.Ship;
using Game.Entities.Ship.Base;
using Game.Factories.Ship.Base;
using Specifications.Ships;

namespace Game.Factories.Ship
{
    public class ShipModel2DFactory : BaseShipModelFactory
    {
        public override IShipModel Create(IShipModel baseModel) => new ShipModel2D(baseModel);
        public override IShipModel Create(ShipSpecification specification) => new ShipModel2D(specification);
    }
}