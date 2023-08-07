using System;
using Global.Dialogs.Base;

namespace Global.Dialogs.History
{
    public class HistoryDialogModel : IGlobalDialogModel
    {
        public event Action OnShow;
        public event Action OnHide;
        
        public void Show()
        {
            OnShow?.Invoke();    
        }

        public void Hide()
        {
            OnHide?.Invoke();
        }
    }
}