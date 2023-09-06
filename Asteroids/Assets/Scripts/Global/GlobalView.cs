using Global.Dialogs.Base;
using Global.Sound;
using Global.UI;
using Specifications.Base;
using UnityEngine;
using UnityEngine.EventSystems;
using Utilities.BaseClasses;

namespace Global
{
    public class GlobalView : BaseSceneView
    {
        [field: SerializeField] public Camera MainCamera { get; private set; }
        [field: SerializeField] public SpecificationsCollectionSo SpecificationsCollection { get; private set; }
        [field: SerializeField] public GlobalUIView GlobalUIView { get; private set; }
        [field: SerializeField] public DialogsView DialogsView { get; private set; }
        [field: SerializeField] public SoundManager SoundManager { get; private set; }
        [field: SerializeField] public EventSystem EventSystem { get; private set; }
    }
}