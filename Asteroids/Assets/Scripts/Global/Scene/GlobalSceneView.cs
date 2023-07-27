using Global.UI;
using UnityEngine;
using Utilities;

namespace Global.Scene
{
    public class GlobalSceneView : BaseSceneView
    {
        [field: SerializeField] public GlobalUIView GlobalUIView { get; protected set; }
    }
}