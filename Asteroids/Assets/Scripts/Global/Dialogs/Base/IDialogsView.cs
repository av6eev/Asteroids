using Global.Dialogs.History.Base;
using Global.Dialogs.Shop.Base;

namespace Global.Dialogs.Base
{
    public interface IDialogsView
    {
        IShopDialogView ShopDialogView { get; }
        IHistoryDialogView HistoryDialogView { get; }
    }
}