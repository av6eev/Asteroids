using UnityEngine;
using Utilities.Interfaces;

namespace Utilities.Joystick.Base
{
    public interface IJoystickView : IUIView
    {
        public RectTransform RectTransform { get; }
        public RectTransform Knob { get; }
    }
}