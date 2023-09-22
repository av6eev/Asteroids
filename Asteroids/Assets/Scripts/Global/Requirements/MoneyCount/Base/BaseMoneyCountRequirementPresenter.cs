using Game.Entities.Ship;
using Global.Base;
using Global.Dialogs.Shop.Base;
using Global.Requirements.Base;
using Utilities.Interfaces;

namespace Global.Requirements.MoneyCount.Base
{
    public abstract class BaseMoneyCountRequirementPresenter<T> : IPresenter where T : BaseMoneyCountRequirement
    {
        private readonly IGlobalEnvironment _environment;
        private readonly T _model;

        protected BaseMoneyCountRequirementPresenter(IGlobalEnvironment environment, IRequirement model)
        {
            _environment = environment;
            _model = (T) model;
        }
        
        public void Activate() => _environment.DialogsModel.GetByType<IShopDialogModel>().OnShipBought += CheckRequirement;

        public void Deactivate() => _environment.DialogsModel.GetByType<IShopDialogModel>().OnShipBought -= CheckRequirement;

        private void CheckRequirement(ShipsTypes type)
        {
            if (_model.ShipType != type) return;
            
            _model.Check(_environment);
        }
    }
}