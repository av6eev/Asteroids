using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Global.Sound
{
    public class SoundManager : MonoBehaviour
    {
        [field: SerializeField] public List<BaseSound> Sounds { get; private set; }
        [field: NonSerialized] public SoundManager Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            
            DontDestroyOnLoad(gameObject);
            
            foreach (var sound in Sounds)
            {
                SetupSourceWithSoundData(sound);
            }
        }
        
        public void PlaySound(SoundsTypes type)
        {
            var sound = Sounds.Find(item => item.Type == type);

            if (sound == null)
            {
                Debug.LogWarning($"Sound with type: {type} isn't found!");
                return;
            }
            
            sound.Source.Play();
        }

        public void Reset()
        {
            foreach (var sound in Sounds.Where(sound => sound.Source.isPlaying))
            {
                sound.Source.Stop();
            }
        }

        public void AddSound(BaseSound sound)
        {
            if (Sounds.Contains(sound))
            {
                Debug.LogWarning($"Sound with type: {sound.Type} already exist!");
                return;
            }
            
            SetupSourceWithSoundData(sound);
            Sounds.Add(sound);
        }

        private void SetupSourceWithSoundData(BaseSound sound)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();

            sound.Source.clip = sound.Clip;
            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.IsLooped;
        }
    }
}