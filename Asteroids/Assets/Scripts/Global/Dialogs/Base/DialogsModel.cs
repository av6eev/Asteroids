using System.Collections.Generic;
using System.Linq;
using Global.Dialogs.Shop;
using Utilities;

namespace Global.Dialogs.Base
{
    public class DialogsModel
    {
        private readonly List<IGlobalDialogModel> _dialogs = new();
        
        public DialogsModel(GameSpecifications specifications)
        {
            Add(new ShopDialogModel(specifications.Ships));
        }

        private void Add(IGlobalDialogModel dialog)
        {
            _dialogs.Add(dialog);
        }

        public TType GetByType<TType>() where TType : IGlobalDialogModel
        {
            return _dialogs.OfType<TType>().First();
        }
    }
}