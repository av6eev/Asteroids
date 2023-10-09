using System;
using System.Collections.Generic;
using Global.Dialogs.History.Base;

namespace Global.Dialogs.History
{
    public class HistoryDialogModel : IHistoryDialogModel
    {
        public event Action OnShow, OnHide, OnScoreAdded;

        private List<int> _bestScores = new();
        private const int MAXIMUM_SCORES_COUNT = 5;

        public void AddScore(int newScore)
        {
            if (_bestScores.Count == 0)
            {
                _bestScores.Add(newScore);
                return;
            }
            
            _bestScores.Add(newScore);
            _bestScores.Sort();
            _bestScores.Reverse();

            if (_bestScores.Count > MAXIMUM_SCORES_COUNT)
            {
                _bestScores.RemoveAt(5);
            }
                        
            OnScoreAdded?.Invoke();
        }
        
        public void SetScoresFromSave(List<int> savedScores)
        {
            if (savedScores == null) return;
            
            _bestScores = savedScores;
        }

        public List<int> GetScores() => _bestScores;

        public void Show() => OnShow?.Invoke();

        public void Hide() => OnHide?.Invoke();
    }
}