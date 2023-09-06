using Game.UI.Base;
using UnityEngine.UI;

namespace Game.UI.EndScreen.Base
{
    public abstract class BaseEndScreenView : BaseGameUIView
    {
        public abstract Button MainMenuButton { get; protected set; }
        
        public abstract void SetData(int distance, int score, int money);
    }
}