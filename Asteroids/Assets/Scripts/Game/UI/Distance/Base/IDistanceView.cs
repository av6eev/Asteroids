using Utilities.Interfaces;

namespace Game.UI.Distance.Base
{
    public interface IDistanceView : IUIView
    {
        public void UpdateDistance(int value);
    }
}