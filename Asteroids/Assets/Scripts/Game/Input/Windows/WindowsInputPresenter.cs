﻿using Game.Input.Base;
using Global;
using Global.Base;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Input.Windows
{
    public class WindowsInputPresenter : BaseInputPresenter
    {
        private readonly IGlobalEnvironment _environment;
        private readonly IInputModel _model;
        private readonly WindowsInputView _view;

        public WindowsInputPresenter(IGlobalEnvironment environment, IInputModel model, BaseInputView view) : base(environment, model, view)
        {
            _environment = environment;
            _model = model;
            _view = (WindowsInputView)view;
        }

        public override void Activate()
        {
            _view.Initialize();
            _view.PlayerInput.actions.Enable();
            
            _view.MoveAction.performed += PerformMove;
            _view.MoveAction.canceled += StopMove;
        
            _model.OnUpdate += Update;
        }
        
        public override void Deactivate()
        {
            _view.MoveAction.performed -= PerformMove;
            _view.MoveAction.canceled -= StopMove;
            
            _view.PlayerInput.actions.Disable();
            
            _model.OnUpdate -= Update;
        }
        
        protected override void Update(float deltaTime)
        {
            if (_view.FireAction.IsPressed() && !CheckPointerOverUI())
            {
                _model.IsShipShooting = true;
                _environment.ShipModel.Shoot();
            }
            else
            {
                _model.IsShipShooting = false;
            }
        }
        
        private void StopMove(InputAction.CallbackContext context) => _model.ShipTurnDirection = 0f;
        
        private void PerformMove(InputAction.CallbackContext context) => _model.ShipTurnDirection = context.ReadValue<Vector2>().x;
    }
}