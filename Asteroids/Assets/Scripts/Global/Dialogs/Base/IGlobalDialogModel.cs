using System;

namespace Global.Dialogs.Base
{
    public interface IGlobalDialogModel
    {
        event Action OnShow, OnHide;
        void Show();
        void Hide();
    }
}