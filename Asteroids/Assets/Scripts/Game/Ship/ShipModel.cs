using Specifications.Ships;

namespace Game.Ship
{
    public class ShipModel
    {
        public ShipSpecification Specification { get; }

        public ShipModel(ShipSpecification specification)
        {
            Specification = specification;
        }
    }
}