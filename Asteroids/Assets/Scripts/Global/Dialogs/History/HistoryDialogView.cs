using Global.Dialogs.Base;
using UnityEngine;
using UnityEngine.UI;

namespace Global.Dialogs.History
{
    public class HistoryDialogView : BaseDialogView
    {
        [field: SerializeField] public Button ExitButton { get; private set; }
    }
}