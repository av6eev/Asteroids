using Game.Input.Base;
using Global;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

namespace Game.Input.Android
{
    public class AndroidInputPresenter : BaseInputPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly IInputModel _model;
        private readonly AndroidInputView _view;

        private Finger _movementFinger;
        private Vector2 _movementAmount;

        public AndroidInputPresenter(GlobalEnvironment environment, IInputModel model, BaseInputView view) : base(environment, model, view)
        {
            _environment = environment;
            _model = model;
            _view = (AndroidInputView)view;
        }

        public override void Activate()
        {
            base.Activate();
            
            _view.Initialize(_environment.GameSceneView.GameUIView.transform);
            EnhancedTouchSupport.Enable();
            
            _view.FireButton.OnDown += StartFire;
            _view.FireButton.OnUp += StopFire;
            
            ETouch.Touch.onFingerDown += HandleFingerDown;
            ETouch.Touch.onFingerUp += HandleFingerUp;
            ETouch.Touch.onFingerMove += HandleFingerMove;
        }

        public override void Deactivate()
        {
            base.Deactivate();

            _view.Dispose();

            _view.FireButton.OnDown -= StartFire;
            _view.FireButton.OnUp -= StopFire;
            
            ETouch.Touch.onFingerDown -= HandleFingerDown;
            ETouch.Touch.onFingerUp -= HandleFingerUp;
            ETouch.Touch.onFingerMove -= HandleFingerMove;
            
            EnhancedTouchSupport.Disable();
        }

        private void StartFire() => _model.IsShipShooting = true;

        private void StopFire() => _model.IsShipShooting = false;

        protected override void  Update(float deltaTime)
        {
            if (_model.IsShipShooting)
            {
                _environment.ShipModel.Shoot();
            }
            
            if (_movementAmount.x != 0f)
            {
               _model.ShipTurnDirection = _movementAmount.x;
            }
        }

        private void HandleFingerDown(Finger finger)
        {
            if (_movementFinger != null || !(finger.screenPosition.x <= Screen.width / 2f)) return;

            _movementAmount = Vector2.zero;
            _movementFinger = finger;
            
            _view.ChangeJoystickVisibility(true);
            _view.SetupJoystickPosition(ClampJoystickPosition(finger.screenPosition));
        }

        private void HandleFingerUp(Finger finger)
        {
            if (finger != _movementFinger) return;

            _model.ShipTurnDirection = 0f;
            
            _movementFinger = null;
            _movementAmount = Vector2.zero;
            
            _view.Joystick.Knob.anchoredPosition = Vector2.zero;
            _view.ChangeJoystickVisibility(false);
        }

        private void HandleFingerMove(Finger finger)
        {
            if (_movementFinger != finger) return;
            
            Vector2 knobPosition;
            var joystickRectTransform = _view.Joystick.RectTransform;
            var maximumMovement = joystickRectTransform.sizeDelta.x / 2f;
            var currentTouch = finger.currentTouch;

            if (Vector2.Distance(currentTouch.screenPosition, joystickRectTransform.anchoredPosition) > maximumMovement)
            {
                knobPosition = (currentTouch.screenPosition - joystickRectTransform.anchoredPosition).normalized * maximumMovement;
            }
            else
            {
                knobPosition = currentTouch.screenPosition - joystickRectTransform.anchoredPosition;
            }

            _view.Joystick.Knob.anchoredPosition = knobPosition;
            _movementAmount = knobPosition / maximumMovement;
        }

        private Vector2 ClampJoystickPosition(Vector2 position)
        {
            var joystick = _view.Joystick;
            var joystickSize = joystick.RectTransform.sizeDelta;
            
            if (position.x < joystickSize.x / 2)
            {
                position.x = joystickSize.x / 2;
            }
            
            if (position.y < joystickSize.y / 2)
            {
                position.y = joystickSize.y / 2;
            }
            else if (position.y > Screen.height - joystickSize.y / 2)
            {
                position.y = Screen.height - joystickSize.y / 2;
            }

            return position;
        }
    }
}