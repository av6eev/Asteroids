using Global.Dialogs.Base;
using Global.UI;
using Specifications.Base;
using UnityEngine;
using Utilities;

namespace Global
{
    public class GlobalView : BaseSceneView
    {
        [field: SerializeField] public Camera MainCamera { get; private set; }
        [field: SerializeField] public SpecificationsCollectionSo SpecificationsCollection { get; private set; }
        [field: SerializeField] public GlobalUIView GlobalUIView { get; private set; }
        [field: SerializeField] public DialogsView DialogsView { get; private set; }
    }
}