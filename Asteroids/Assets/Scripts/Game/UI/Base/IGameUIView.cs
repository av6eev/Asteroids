using System;
using Game.UI.Difficulty;
using Game.UI.Distance;
using Game.UI.EndScreen;
using Game.UI.Health;
using Game.UI.Money;
using Game.UI.Score;
using Utilities.Interfaces;

namespace Game.UI.Base
{
    public interface IGameUIView : IUIView, ISubscriptionableUI
    {
        event Action OnCameraChanged;
        
        ScoreView ScoreView { get; }
        DistanceView DistanceView { get; }
        HealthView HealthView { get; }
        MoneyView MoneyView { get; }
        DifficultyView DifficultyView { get; }
        EndScreenView EndScreenView { get; }
        
        void HideElementsAfterEnd();
    }
}