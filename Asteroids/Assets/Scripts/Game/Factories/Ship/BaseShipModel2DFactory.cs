using Game.Entities.Ship;
using Game.Entities.Ship.Base;
using Game.Factories.Ship.Base;
using Specifications.Ships;

namespace Game.Factories.Ship
{
    public class BaseShipModel2DFactory : BaseShipModelFactory
    {
        public override IShipModel TryCreate(IShipModel baseModel) => new ShipModel2D(baseModel);
        public override IShipModel TryCreate(ShipSpecification specification) => new ShipModel2D(specification);
    }
}