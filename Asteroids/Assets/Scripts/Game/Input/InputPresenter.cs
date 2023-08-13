using UnityEngine;
using UnityEngine.InputSystem;
using Utilities;

namespace Game.Input
{
    public class InputPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly InputModel _model;
        private readonly InputView _view;

        public InputPresenter(GlobalEnvironment environment, InputModel model, InputView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _view.PlayerInputAsset.actions.Enable();
            
            _view.MoveAction.performed += PerformMove;
            _view.MoveAction.canceled += StopMove;

            _model.OnUpdate += Update;
        }

        public void Deactivate()
        {
            _view.MoveAction.performed -= PerformMove;
            _view.MoveAction.canceled -= StopMove;
            
            _view.PlayerInputAsset.actions.Disable();
            
            _model.OnUpdate -= Update;
            
            Debug.Log(nameof(InputPresenter) + " deactivated!");
        }

        private void Update(float deltaTime)
        {
            if (_view.FireAction.IsPressed())
            {
                _model.IsShipShooting = true;
                _environment.ShipModel.Shoot();
            }
            else
            {
                _model.IsShipShooting = false;
            }
        }

        private void StopMove(InputAction.CallbackContext context)
        {
            _model.IsShipRotating = false;
            _model.ShipRotateDirection = 0f;     
        }

        private void PerformMove(InputAction.CallbackContext context)
        {
            _model.IsShipRotating = true;
            _model.ShipRotateDirection = context.ReadValue<Vector2>().x;
        }
    }
}