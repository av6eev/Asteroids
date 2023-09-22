﻿using System;
using Game.Entities.Ship;
using Global.Requirements.MoneyCount.Base;
using UnityEngine;

namespace Global.Requirements.MoneyCount.Polruan
{
    [Serializable]
    public class PolruanMoneyCountRequirement : BaseMoneyCountRequirement
    {
        [field: SerializeField] public override string RewardName { get; set; }
        [field: SerializeField] public override ShipsTypes ShipType { get; set; }
    }
}