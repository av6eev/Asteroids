using System;
using UnityEngine;

namespace Utilities.BaseClasses
{
    [Serializable]
    public class ShipPreviewImage : IPreviewImage
    {
        [field: SerializeField] public Sprite PreviewImage { get; private set; }
    }
}