using Global;
using UnityEngine.EventSystems;
using Utilities.Interfaces;

namespace Game.Input.Base
{
    public abstract class BaseInputPresenter : IPresenter
    {
        private readonly IInputModel _model;

        protected BaseInputPresenter(IGlobalEnvironment environment, IInputModel model, BaseInputView view) => _model = model;

        public virtual void Activate() => _model.OnUpdate += Update;

        public virtual void Deactivate() => _model.OnUpdate += Update;

        protected abstract void Update(float deltaTime);
        
        protected bool CheckPointerOverUI() => EventSystem.current.IsPointerOverGameObject();
    }
}