using System;

namespace Game
{
    public class GameModel
    {
        public event Action OnClosed, OnEnded;

        public void Close()
        {
            OnClosed?.Invoke();
        }

        public void End()
        {
            OnEnded?.Invoke();
        }
    }
}