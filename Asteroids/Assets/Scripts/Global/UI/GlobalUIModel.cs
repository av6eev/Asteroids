using System;
using System.Collections.Generic;
using Game.Entities.Ship;

namespace Global.UI
{
    public class GlobalUIModel
    {
        public event Action<int> OnShipChanged;
        
        private int _selectedShipId;
        public int SelectedShipId
        {
            get => _selectedShipId;
            private set
            {
                if (value <= 0)
                {
                    _selectedShipId = 1;
                    throw new ArgumentOutOfRangeException($"Try to set negative or 0 value: {value} to SelectedShipId! Variable is set to 1 (default).");
                }
                
                _selectedShipId = value;
            }
        }

        public Dictionary<ShipsTypes, bool> AvailableShips { get; private set; } = new();

        public void SetAvailableShips(Dictionary<ShipsTypes, bool> ships) => AvailableShips = ships;

        public void UpdateAvailableShips(ShipsTypes type, bool state)
        {
            if (AvailableShips.ContainsKey(type))
            {
                AvailableShips[type] = state;
            }
        }

        public void SetSelectedShip(int id)
        {
            SelectedShipId = id;
            OnShipChanged?.Invoke(SelectedShipId);
        }
    }
}