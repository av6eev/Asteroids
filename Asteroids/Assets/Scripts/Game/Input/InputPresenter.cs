using UnityEngine;
using UnityEngine.InputSystem;
using Utilities;

namespace Game.Input
{
    public class InputPresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly InputModel _model;
        private readonly InputView _view;

        public InputPresenter(GameEnvironment environment, InputModel model, InputView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _view.PlayerInputAsset.actions.Enable();
            
            _view.MoveAction.performed += PerformMove;
            _view.MoveAction.canceled += CancelMove;
        }

        public void Deactivate()
        {
            _view.MoveAction.performed -= PerformMove;
            _view.MoveAction.canceled -= CancelMove;
            
            _view.PlayerInputAsset.actions.Disable();
        }

        private void CancelMove(InputAction.CallbackContext context)
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