using Global.UI;
using Specifications.Base;
using UnityEngine;
using Utilities;

namespace Global
{
    public class GlobalView : BaseSceneView
    {
        [field: SerializeField] public Camera MainCamera { get; protected set; }
        [field: SerializeField] public SpecificationsCollectionSo SpecificationsCollection { get; protected set; }
        [field: SerializeField] public GlobalUIView GlobalUIView { get; protected set; }
    }
}