using System;
using Game.Input.Base;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Input.Windows
{
    public class WindowsInputView : BaseInputView
    {
        [field: SerializeField] public override PlayerInput PlayerInput { get; set; }
        [field: NonSerialized] public InputAction MoveAction { get; private set; }
        [field: NonSerialized] public InputAction FireAction { get; private set; }

        public void Initialize()
        {
            MoveAction = PlayerInput.actions.actionMaps[0].actions[0];
            FireAction = PlayerInput.actions.actionMaps[0].actions[1];
        }
    }
}