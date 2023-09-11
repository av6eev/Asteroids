using Utilities.Interfaces;

namespace Game.Input
{
    public interface IInputModel : IUpdatable
    {
        public bool IsShipShooting { get; set; }
        public float ShipTurnDirection { get; set; }
    }
}