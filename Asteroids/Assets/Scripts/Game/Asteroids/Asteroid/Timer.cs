using System;
using Utilities;

namespace Game.Asteroids.Asteroid
{
    public class Timer : ITimer
    {
        public event Action OnTick;
        
        private readonly float _givenTime;
        private float _currentTime;
        
        private readonly bool _isLooped;
        private bool _isElapsed;

        public Timer(float givenTime, bool isLooped)
        {
            _givenTime = givenTime;
            _isLooped = isLooped;
        }
        
        public void Update(float deltaTime)
        {
            _currentTime += deltaTime;

            if (!(_currentTime > _givenTime) || _isElapsed) return;
            
            OnTick?.Invoke();
                
            if (_isLooped)
            {
                _currentTime -= _givenTime;
            }
            else
            {
                _isElapsed = true;
            }
        }

        public void Reset()
        {
            _currentTime = 0;
        }
    }
}