using System.Collections.Generic;
using System.Linq;
using Global.Dialogs.Base;
using Global.Dialogs.History;
using Global.Dialogs.Shop;

namespace Global.Dialogs
{
    public class DialogsModel : IDialogsModel
    {
        private readonly List<IGlobalDialogModel> _dialogs = new();
        
        public DialogsModel()
        {
            Add(new ShopDialogModel());
            Add(new HistoryDialogModel());
        }

        private void Add(IGlobalDialogModel dialog) => _dialogs.Add(dialog);

        public TType GetByType<TType>() where TType : IGlobalDialogModel => _dialogs.OfType<TType>().First();
    }
}