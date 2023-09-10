using Global.Dialogs.Shop;
using Global.Requirements.Base;
using Specifications.Ships;
using Utilities.Interfaces;

namespace Global.Requirements.MoneyCount.Base
{
    public abstract class BaseMoneyCountRequirementPresenter<T> : IPresenter where T : BaseMoneyCountRequirement
    {
        private readonly GlobalEnvironment _environment;
        private readonly T _model;

        protected BaseMoneyCountRequirementPresenter(GlobalEnvironment environment, IRequirement model)
        {
            _environment = environment;
            _model = (T) model;
        }
        
        public void Activate() => _environment.DialogsModel.GetByType<ShopDialogModel>().OnShipBought += CheckRequirement;

        public void Deactivate() => _environment.DialogsModel.GetByType<ShopDialogModel>().OnShipBought -= CheckRequirement;

        private void CheckRequirement(ShipSpecification specification)
        {
            if (_model.ShipType != specification.Type) return;
            
            _model.Check(_environment);
        }
    }
}