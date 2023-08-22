using System.Collections.Generic;
using Global.Dialogs.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Global.Dialogs.History
{
    public class HistoryDialogView : BaseDialogView
    {
        [field: Header("Order of elements is important!")]
        [field: SerializeField] public List<TextMeshProUGUI> Scores { get; private set; }
        [field: SerializeField] public Button ExitButton { get; private set; }

        public void SetScores(List<int> scores)
        {
            if (scores.Count == 0) return;
            
            for (var i = 0; i < scores.Count; i++)
            {
                var scoreByIndex = scores[i];
                var field = Scores[i];

                if (scoreByIndex == 0) continue;

                field.fontSize = 36;
                field.color = Color.white;
                field.text = scoreByIndex.ToString();
            }
        }
    }
}