using System;
using Game.Entities.Ship;
using Global.Requirements.MoneyCount.Base;
using UnityEngine;

namespace Global.Requirements.MoneyCount.Sartine
{
    [Serializable]
    public class SartineMoneyCountRequirement : BaseMoneyCountRequirement
    {
        [field: SerializeField] public override string RewardName { get; set; }
        [field: SerializeField] public override ShipsTypes ShipType { get; set; }
    }
}