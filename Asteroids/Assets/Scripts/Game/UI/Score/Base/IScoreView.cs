using Utilities.Interfaces;

namespace Game.UI.Score.Base
{
    public interface IScoreView : IUIView
    {
        public void UpdateScore(int score);
    }
}