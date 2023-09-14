using Game.UI.Base;
using UnityEngine.InputSystem;

namespace Game.Input.Base
{
    public abstract class BaseInputView : BaseGameUIView
    {
        public abstract PlayerInput PlayerInput { get; set; }
    }
}