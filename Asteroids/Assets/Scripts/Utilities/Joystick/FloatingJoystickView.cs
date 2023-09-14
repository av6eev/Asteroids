using UnityEngine;
using Utilities.Joystick.Base;

namespace Utilities.Joystick
{
    [RequireComponent(typeof(RectTransform))]
    public class FloatingJoystickView : BaseJoystickView
    {
        [field: SerializeField] public override RectTransform RectTransform { get; set; }
        [field: SerializeField] public override RectTransform Knob { get; set; }
    }
}