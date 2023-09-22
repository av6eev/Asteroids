using System;
using Game.Base;
using Specifications.GameDifficulties;
using UnityEngine;
using Utilities.Enums;
using Utilities.Game;

namespace Game
{
    public class GameModel : IGameModel
    {
        public event Action<GameDifficultySpecification> OnDifficultyIncreased;
        public event Action OnClosed, OnEnded, OnDimensionChanged;
        public event Action<int> OnLivesChanged;

        private float _currentMoney;
        public float CurrentMoney
        {
            get => _currentMoney;
            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException($"Try to set negative value: {value} to CurrentMoney");
                _currentMoney = value;
            }
        }

        private int _currentScore;
        public int CurrentScore
        {
            get => _currentScore;
            private set
            {
                if (value < 0) throw new ArgumentOutOfRangeException($"Try to set negative value: {value} to CurrentScore");
                _currentScore = value;
            }
        }
        
        private int _currentLives;
        public int CurrentLives
        {
            get => _currentLives;
            private set
            {
                if (value <= 0) OnEnded?.Invoke();
                
                _currentLives = value;
                OnLivesChanged?.Invoke(_currentLives);
            }
        }

        public int CurrentDistance { get; private set; }
        public CameraDimensionsTypes CurrentDimension { get; private set; } = CameraDimensionsTypes.TwoD;
        public GameZoneLimits ZoneLimits { get; } = new();

        public void UpdateDistance(int distance) => CurrentDistance = Mathf.Abs(distance);

        public void UpdateScore(int bonus) => CurrentScore += bonus;

        public void UpdateBalance(float bonus) => CurrentMoney += bonus;

        public void UpdateDifficulty(GameDifficultySpecification newDifficultySpecification) => OnDifficultyIncreased?.Invoke(newDifficultySpecification);

        public void UpdateLives(int currentHealth) => CurrentLives = currentHealth;
        
        public int CalculateGainedMoney() => CurrentDistance / 400 + Convert.ToInt32(Math.Floor(CurrentMoney));

        public void Close() => OnClosed?.Invoke();

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