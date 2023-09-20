using Global.Dialogs.History;
using Global.Dialogs.Shop;

namespace Global.Dialogs.Base
{
    public interface IDialogsView
    {
        ShopDialogView ShopDialogView { get; }
        HistoryDialogView HistoryDialogView { get; }
    }
}