using System;
using Game.UI.Base;
using UnityEngine.EventSystems;

namespace Utilities.FireButton
{
    public abstract class BaseFireButtonView : BaseGameUIView, IPointerDownHandler, IPointerUpHandler
    {
        public event Action OnDown;
        public event Action OnUp;
        
        public virtual void OnPointerDown(PointerEventData eventData) => OnDown?.Invoke();

        public virtual void OnPointerUp(PointerEventData eventData) => OnUp?.Invoke();
    }
}