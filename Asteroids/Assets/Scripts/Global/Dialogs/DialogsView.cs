﻿using Global.Dialogs.Base;
using Global.Dialogs.History;
using Global.Dialogs.Shop;
using UnityEngine;

namespace Global.Dialogs
{
    public class DialogsView : MonoBehaviour, IDialogsView
    {
        [field: SerializeField] public ShopDialogView ShopDialogView { get; private set; }
        [field: SerializeField] public HistoryDialogView HistoryDialogView { get; private set; }
    }
}