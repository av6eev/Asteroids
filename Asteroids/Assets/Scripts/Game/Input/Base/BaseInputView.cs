using UnityEngine;
using UnityEngine.InputSystem;
using Utilities.Interfaces;

namespace Game.Input.Base
{
    public abstract class BaseInputView : MonoBehaviour, IUIView
    {
        public abstract PlayerInput PlayerInput { get; set; }
        
        public abstract void Show();
        public abstract void Hide();
    }
}