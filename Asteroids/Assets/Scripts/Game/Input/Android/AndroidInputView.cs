using System;
using Game.Input.Base;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilities.FireButton;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;
using Utilities.Joystick.Base;

namespace Game.Input.Android
{
    public class AndroidInputView : BaseInputView
    {
        [field: SerializeField] public override PlayerInput PlayerInput { get; set; }
        [field: NonSerialized] public BaseJoystickView Joystick { get; private set; }
        [field: NonSerialized] public BaseFireButtonView FireButton { get; private set; }

        public void Initialize(Transform joystickParent)
        {
            Joystick = Instantiate(Resources.Load<BaseJoystickView>("UI/Joystick/Floating Joystick"), joystickParent);
            FireButton = Instantiate(Resources.Load<BaseFireButtonView>("UI/FireButton/FireBtn"), joystickParent);
            
            ChangeJoystickVisibility(false);
        }

        public void ChangeJoystickVisibility(bool state) => Joystick.ChangeVisibility(state);

        public void SetupJoystickPosition(Vector2 newPosition) => Joystick.RectTransform.position = newPosition;

        public void Dispose()
        {
            Destroy(Joystick.gameObject);
            Destroy(FireButton.gameObject);
        }
    }
}