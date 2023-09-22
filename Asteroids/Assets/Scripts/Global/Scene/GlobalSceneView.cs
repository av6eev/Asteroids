using Global.Dialogs;
using Global.Dialogs.Base;
using Global.Sound;
using Global.UI;
using Global.UI.Base;
using Specifications.Base;
using UnityEngine;
using UnityEngine.EventSystems;
using Utilities.BaseClasses;

namespace Global.Scene
{
    public class GlobalSceneView : BaseSceneView, IGlobalSceneView
    {
        [field: SerializeField] public Camera MainCamera { get; private set; }
        [field: SerializeField] public SpecificationsCollectionSo SpecificationsCollection { get; private set; }
        [field: SerializeField] public GlobalUIView GlobalUIViewGo { get; private set; }
        [field: SerializeField] public DialogsView DialogsViewGo { get; private set; }
        [field: SerializeField] public SoundManager SoundManagerGo { get; private set; }
        [field: SerializeField] public EventSystem EventSystem { get; private set; }

        public IGlobalUIView GlobalUIView => GlobalUIViewGo;
        public IDialogsView DialogsView => DialogsViewGo;
        public ISoundManager SoundManager => SoundManagerGo;
        
        public void DisableCamera() => MainCamera.gameObject.SetActive(false);

        public void EnableCamera() => MainCamera.gameObject.SetActive(true);
        
        public void EnableEventSystem() => EventSystem.enabled = true;

        public void DisableEventSystem() => EventSystem.enabled = false;
    }
}