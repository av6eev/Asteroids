using Game.UI.Base;

namespace Game.UI.Health.Base
{
    public abstract class BaseHealthView : BaseGameUIView
    {
        public abstract void UpdateHealth(float value);
        public abstract void SetStartedHealth(int maxHealth);
    }
}