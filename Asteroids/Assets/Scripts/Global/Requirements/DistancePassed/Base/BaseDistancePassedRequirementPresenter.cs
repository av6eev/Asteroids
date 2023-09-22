using Global.Base;
using Global.Requirements.Base;
using Utilities.Interfaces;

namespace Global.Requirements.DistancePassed.Base
{
    public abstract class BaseDistancePassedRequirementPresenter<T> : IPresenter where T : BaseDistancePassedRequirement
    {
        private readonly IGlobalEnvironment _environment;
        private readonly T _model;

        protected BaseDistancePassedRequirementPresenter(IGlobalEnvironment environment, IRequirement model)
        {
            _environment = environment;
            _model = (T) model;
        }
        
        public void Activate() => _environment.ShipModel.MoveModel.OnUpdate += Check;

        public void Deactivate() => _environment.ShipModel.MoveModel.OnUpdate -= Check;

        private void Check(float deltaTime)
        {
            if (_model.Check(_environment))
            {
                Deactivate();
            }
        }
    }
}