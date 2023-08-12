using System;

namespace Game
{
    public class GameModel
    {
        public event Action OnGameEnded;

        public void EndGame()
        {
            OnGameEnded?.Invoke();
        }
    }
}