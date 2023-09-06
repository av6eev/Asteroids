using Game.UI.Base;

namespace Game.UI.Score.Base
{
    public abstract class BaseScoreView : BaseGameUIView
    {
        public abstract void UpdateScore(int score);
    }
}