using System;
using System.Collections.Generic;
using Global.Dialogs.Base;

namespace Global.Dialogs.History.Base
{
    public interface IHistoryDialogView : IDialogView
    {
        event Action OnExitClicked;

        void SetScores(List<int> scores);
    }
}