using System;
using Specifications.GameDifficulties;
using Utilities.Enums;
using Utilities.Game;

namespace Game.Base
{
    public interface IGameModel
    {
        event Action<GameDifficultySpecification> OnDifficultyIncreased;
        event Action OnClosed, OnEnded, OnDimensionChanged;
        event Action<int> OnLivesChanged;
        
        float CurrentMoney { get; }
        int CurrentScore { get; }
        int CurrentLives { get; }
        int CurrentDistance { get; }
        CameraDimensionsTypes CurrentDimension { get; }
        GameZoneLimits ZoneLimits { get; }

        void UpdateDistance(int distance);
        void UpdateScore(int bonus);
        void UpdateBalance(float bonus);
        void UpdateDifficulty(GameDifficultySpecification newDifficultySpecification);
        void UpdateLives(int currentHealth);
        int CalculateGainedMoney();
        void Close();
        void ChangeDimension(int index);
    }
}