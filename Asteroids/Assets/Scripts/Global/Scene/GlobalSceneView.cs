using Global.Dialogs;
using Global.Sound;
using Global.UI;
using Specifications.Base;
using UnityEngine;
using UnityEngine.EventSystems;
using Utilities.BaseClasses;

namespace Global.Scene
{
    public class GlobalSceneView : BaseSceneView
    {
        [field: SerializeField] public Camera MainCamera { get; private set; }
        [field: SerializeField] public SpecificationsCollectionSo SpecificationsCollection { get; private set; }
        [field: SerializeField] public GlobalUIView GlobalUIView { get; private set; }
        [field: SerializeField] public DialogsView DialogsView { get; private set; }
        [field: SerializeField] public SoundManager SoundManager { get; private set; }
        [field: SerializeField] public EventSystem EventSystem { get; private set; }
    }
}