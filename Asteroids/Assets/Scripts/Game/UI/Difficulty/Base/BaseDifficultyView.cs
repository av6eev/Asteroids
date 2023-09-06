using Game.UI.Base;

namespace Game.UI.Difficulty.Base
{
    public abstract class BaseDifficultyView : BaseGameUIView
    {
        public abstract void UpdateDifficulty(int difficulty);
    }
}