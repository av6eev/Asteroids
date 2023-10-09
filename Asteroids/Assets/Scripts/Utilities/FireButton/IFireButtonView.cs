using System;
using Utilities.Interfaces;

namespace Utilities.FireButton
{
    public interface IFireButtonView : IUIView
    {
        public event Action OnDown;
        public event Action OnUp;
    }
}