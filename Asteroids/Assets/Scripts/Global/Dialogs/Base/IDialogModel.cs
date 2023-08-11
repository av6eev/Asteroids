using System;

namespace Global.Dialogs.Base
{
    public interface IDialogModel
    {
        event Action OnShow, OnHide;
        void Show();
        void Hide();
    }
}