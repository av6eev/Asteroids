using System;
using UnityEngine;

namespace Global.Sound
{
    [Serializable]
    public class BaseSound
    {
        [field: SerializeField] public SoundsTypes Type { get; private set; }
        [field: SerializeField] public AudioClip Clip { get; private set; }
        [field: SerializeField] [field: Range(0f, 1f)] public float Volume { get; private set; }
        [field: SerializeField] [field: Range(.1f, 5f)] public float Pitch { get; private set; }
        [field: SerializeField] public bool IsLooped { get; private set; }
        
        [field: HideInInspector] public AudioSource Source { get; set; }
    }
}