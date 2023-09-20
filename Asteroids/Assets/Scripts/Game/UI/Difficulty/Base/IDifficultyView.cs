using Utilities.Interfaces;

namespace Game.UI.Difficulty.Base
{
    public interface IDifficultyView : IUIView
    {
        void UpdateDifficulty(int difficulty);
    }
}