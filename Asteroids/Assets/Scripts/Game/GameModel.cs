using System;
using Specifications.GameDifficulties;
using UnityEngine;
using Utilities.Enums;
using Utilities.Game;

namespace Game
{
    public class GameModel
    {
        public event Action<GameDifficultySpecification> OnDifficultyIncreased;
        public event Action OnClosed, OnEnded, OnDimensionChanged;

        private float _currentMoney;
        public float CurrentMoney
        {
            get => _currentMoney;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"Try to set negative value: {value} to CurrentMoney");
                }
                
                _currentMoney = value;
            }
        }

        private int _currentScore;
        public int CurrentScore
        {
            get => _currentScore;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException($"Try to set negative value: {value} to CurrentScore");
                }
                
                _currentScore = value;
            }
        }

        public int CurrentDistance { get; private set; }
        public CameraDimensionsTypes CurrentDimension { get; private set; } = CameraDimensionsTypes.TwoD;
        public GameZoneLimits ZoneLimits { get; } = new();

        public void UpdateDistance(int distance) => CurrentDistance = Mathf.Abs(distance);

        public void UpdateScore(int bonus) => CurrentScore += bonus;

        public void UpdateBalance(float bonus) => CurrentMoney += bonus;

        public int CalculateGainedMoney() => CurrentDistance / 400 + Convert.ToInt32(Math.Floor(CurrentMoney));
        
        public void UpdateDifficulty(GameDifficultySpecification newDifficultySpecification) => OnDifficultyIncreased?.Invoke(newDifficultySpecification);

        public void Close() => OnClosed?.Invoke();

        public void End() => OnEnded?.Invoke();

        public void ChangeDimension(int index)
        {
            CurrentDimension = index switch
            {
                0 => CameraDimensionsTypes.TwoD,
                1 => CameraDimensionsTypes.ThreeD,
                _ => CurrentDimension
            };

            OnDimensionChanged?.Invoke();
        }
    }
}