using System.Collections.Generic;
using Game.Ship;

namespace Global.UI
{
    public class GlobalUIModel
    {
        public int SelectedShipId = 1;
        public Dictionary<ShipsTypes, bool> AvailableShips { get; private set; } = new();

        public void SetAvailableShips(Dictionary<ShipsTypes, bool> ships) => AvailableShips = ships;
    }
}