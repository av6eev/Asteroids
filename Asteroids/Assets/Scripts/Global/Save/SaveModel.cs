using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Global.Save
{
    public class SaveModel
    {
        public event Action OnSave, OnDeserialize;

        public void Save()
        {
            OnSave?.Invoke();
        }

        public void Deserialize()
        {
            OnDeserialize?.Invoke();
        }

        public T GetElement<T>(string key) => PlayerPrefs.HasKey(key) ? JsonConvert.DeserializeObject<T>(PlayerPrefs.GetString(key)) : default;

        public void SaveElement<T>(string key, T value) => PlayerPrefs.SetString(key, JsonConvert.SerializeObject(value));
    }
}