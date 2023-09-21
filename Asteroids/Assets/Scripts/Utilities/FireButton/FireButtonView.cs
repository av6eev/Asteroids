using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Utilities.FireButton
{
    public class FireButtonView : MonoBehaviour, IFireButtonView, IPointerDownHandler, IPointerUpHandler
    {
        public event Action OnDown;
        public event Action OnUp;
        
        public void Show() => gameObject.SetActive(true);
        
        public void Hide() => gameObject.SetActive(false);

        public void OnPointerDown(PointerEventData eventData) => OnDown?.Invoke();

        public void OnPointerUp(PointerEventData eventData) => OnUp?.Invoke();
    }
}