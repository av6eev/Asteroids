using Game.Entities.Ship.Base;
using Specifications.Ships;

namespace Game.Factories.Ship.Base
{
    public abstract class BaseShipModelFactory
    {
        public abstract IShipModel TryCreate(IShipModel baseModel);
        public abstract IShipModel TryCreate(ShipSpecification specification);
    }
}