using System;
using Game.Ship;
using UnityEngine;

namespace Global.Requirements.MoneyCount.BlueShip
{
    [Serializable]
    public class BlueShipMoneyCountRequirement : BaseMoneyCountRequirement
    {
        [field: SerializeField] public override ShipsTypes ShipType { get; protected set; }
    }
}