using System;

namespace Global.Save.Base
{
    public interface ISaveModel
    {
        event Action OnSave, OnDeserialize;
        
        void Save();
        void Deserialize();
        void SaveElement<T>(string key, T value);
        T GetElement<T>(string key);
    }
}