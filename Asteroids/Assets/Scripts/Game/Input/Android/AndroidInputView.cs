using System;
using Game.Input.Base;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilities.FireButton;
using Utilities.Joystick;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;
using Utilities.Joystick.Base;

namespace Game.Input.Android
{
    public class AndroidInputView : BaseInputView
    {
        [field: SerializeField] public override PlayerInput PlayerInput { get; set; }
        [field: NonSerialized] public IJoystickView Joystick { get; private set; }
        [field: NonSerialized] public IFireButtonView FireButton { get; private set; }

        public void Initialize(Transform joystickParent)
        {
            Joystick = Instantiate(Resources.Load<FloatingJoystickView>("UI/Joystick/Floating Joystick"), joystickParent);
            FireButton = Instantiate(Resources.Load<FireButtonView>("UI/FireButton/FireBtn"), joystickParent);
            
            Joystick.Hide();
        }

        public void Dispose()
        {
            Destroy(((MonoBehaviour)Joystick).gameObject);
            Destroy(((MonoBehaviour)FireButton).gameObject);
        }

        public void SetupJoystickPosition(Vector2 newPosition) => Joystick.RectTransform.position = newPosition;

        public override void Show() => gameObject.SetActive(true);

        public override void Hide() => gameObject.SetActive(false);
    }
}