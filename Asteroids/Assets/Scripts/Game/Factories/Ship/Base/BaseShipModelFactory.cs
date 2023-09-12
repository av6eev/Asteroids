using Game.Entities.Ship.Base;
using Specifications.Ships;

namespace Game.Factories.Ship.Base
{
    public abstract class BaseShipModelFactory
    {
        public abstract IShipModel Create(IShipModel baseModel);
        public abstract IShipModel Create(ShipSpecification specification);
    }
}