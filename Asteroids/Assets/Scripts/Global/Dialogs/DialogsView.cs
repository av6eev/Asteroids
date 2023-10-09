using Global.Dialogs.Base;
using Global.Dialogs.History;
using Global.Dialogs.History.Base;
using Global.Dialogs.Shop;
using Global.Dialogs.Shop.Base;
using UnityEngine;

namespace Global.Dialogs
{
    public class DialogsView : MonoBehaviour, IDialogsView
    {
        [field: SerializeField] public ShopDialogView ShopDialogViewGo { get; private set; }
        [field: SerializeField] public HistoryDialogView HistoryDialogViewGo { get; private set; }

        public IShopDialogView ShopDialogView => ShopDialogViewGo;
        public IHistoryDialogView HistoryDialogView => HistoryDialogViewGo;
    }
}