using System;

namespace Global.Save
{
    public class SaveModel
    {
        public event Action OnSave;
        public event Action<ISavable> OnSaveElement; 

        public void Save()
        {
            OnSave?.Invoke();
        }

        public void SaveElement<TSavable>(TSavable model) where TSavable : ISavable
        {
            OnSaveElement?.Invoke(model);
        }
    }
}