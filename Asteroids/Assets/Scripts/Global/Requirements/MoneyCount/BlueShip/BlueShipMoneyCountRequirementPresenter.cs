using Game.Ship;
using Global.Dialogs.Shop;
using Global.Requirements.Base;
using Utilities;

namespace Global.Requirements.MoneyCount.BlueShip
{
    public class BlueShipMoneyCountRequirementPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly BlueShipMoneyCountRequirement _model;

        public BlueShipMoneyCountRequirementPresenter(GlobalEnvironment environment, IRequirement model)
        {
            _environment = environment;
            _model = (BlueShipMoneyCountRequirement) model;
        }
        
        public void Activate() => _environment.DialogsModel.GetByType<ShopDialogModel>().OnShipBought += CheckRequirement;

        public void Deactivate() => _environment.DialogsModel.GetByType<ShopDialogModel>().OnShipBought -= CheckRequirement;

        private void CheckRequirement(ShipsTypes type, int price)
        {
            if (_model.ShipType != type) return;
            if (!_model.Check(_environment)) return;
            
            _environment.SaveModel.SaveElement(nameof(BlueShipMoneyCountRequirement), "true");
            _environment.SaveModel.Deserialize();
        }
    }
}