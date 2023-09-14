using Game.UI.Base;
using UnityEngine;

namespace Utilities.Joystick.Base
{
    public abstract class BaseJoystickView : BaseGameUIView
    {
        public abstract RectTransform RectTransform { get; set; }
        public abstract RectTransform Knob { get; set; }
    }
}