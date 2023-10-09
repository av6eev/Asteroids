using UnityEngine;
using Utilities.Joystick.Base;

namespace Utilities.Joystick
{
    [RequireComponent(typeof(RectTransform))]
    public class FloatingJoystickView : MonoBehaviour, IJoystickView
    {
        [field: SerializeField] public RectTransform RectTransform { get; private set; }
        [field: SerializeField] public RectTransform Knob { get; private set; }
        
        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}