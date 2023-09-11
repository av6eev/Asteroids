namespace Global.Dialogs.Base
{
    public interface IDialogsModel
    {
        TType GetByType<TType>() where TType : IGlobalDialogModel;
    }
}