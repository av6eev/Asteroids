using System;
using UnityEngine.EventSystems;
using Utilities.Interfaces;

namespace Utilities.FireButton
{
    public interface IFireButtonView : IUIView, IPointerDownHandler, IPointerUpHandler
    {
        public event Action OnDown;
        public event Action OnUp;
    }
}