using System;
using System.Collections.Generic;
using Global.Dialogs.Base;

namespace Global.Dialogs.History.Base
{
    public interface IHistoryDialogModel : IGlobalDialogModel
    {
        event Action OnScoreAdded;

        public void AddScore(int newScore);
        public void SetScoresFromSave(List<int> savedScores);
        public List<int> GetScores();
    }
}