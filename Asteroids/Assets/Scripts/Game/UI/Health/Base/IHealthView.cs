using Utilities.Interfaces;

namespace Game.UI.Health.Base
{
    public interface IHealthView : IUIView
    {
        public void UpdateHealth(float value);
        public void SetStartedHealth(int maxHealth);
    }
}