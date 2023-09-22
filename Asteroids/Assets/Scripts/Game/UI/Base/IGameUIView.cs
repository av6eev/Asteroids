using System;
using Game.UI.Difficulty.Base;
using Game.UI.Distance.Base;
using Game.UI.EndScreen.Base;
using Game.UI.Health.Base;
using Game.UI.Money.Base;
using Game.UI.Score.Base;
using Utilities.Interfaces;

namespace Game.UI.Base
{
    public interface IGameUIView : IUIView, ISubscriptionableUI
    {
        event Action OnCameraChanged;
        
        IScoreView ScoreView { get; }
        IDistanceView DistanceView { get; }
        IHealthView HealthView { get; }
        IMoneyView MoneyView { get; }
        IDifficultyView DifficultyView { get; }
        IEndScreenView EndScreenView { get; }
        
        void HideElementsAfterEnd();
    }
}