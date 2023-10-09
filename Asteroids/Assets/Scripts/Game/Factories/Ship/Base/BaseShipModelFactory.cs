using Game.Entities.Ship.Base;
using Specifications.Ships;
using Specifications.Ships.Base;

namespace Game.Factories.Ship.Base
{
    public abstract class BaseShipModelFactory
    {
        public abstract IShipModel Create(IShipModel baseModel);
        public abstract IShipModel Create(IShipSpecification specification);
    }
}