using System;
using System.Collections.Generic;
using Game.Entities.Ship;

namespace Global.UI
{
    public interface IGlobalUIModel
    {
        event Action<int> OnShipChanged;
        int SelectedShipId { get; }
        Dictionary<ShipsTypes, bool> AvailableShips { get; }
        void SetAvailableShips(Dictionary<ShipsTypes, bool> ships);
        void UpdateAvailableShips(ShipsTypes type, bool state);
        void SetSelectedShip(int id);
    }
}