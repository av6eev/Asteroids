using System;
using Game.Input.Base;
using Game.UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilities.BaseClasses;
using Utilities.Enums;

namespace Game.Scene
{
    public class GameSceneView : BaseSceneView
    {
        [field: SerializeField] public Camera TopDownCamera { get; private set; }
        [field: SerializeField] public Camera ThirdPersonCamera { get; private set; }
        [field: SerializeField] public GameView GameView { get; private set; }
        [field: SerializeField] public GameUIView GameUIView { get; private set; }
        [field: SerializeField] public InputActionAsset PlayerInputAsset { get; private set; }
        [field: NonSerialized] public BaseInputView InputView { get; private set; }

        public void SwitchCamera(CameraDimensionsTypes type)
        {
            switch (type)
            {
                case CameraDimensionsTypes.TwoD:
                    TopDownCamera.gameObject.SetActive(true);
                    ThirdPersonCamera.gameObject.SetActive(false);
                    break;
                case CameraDimensionsTypes.ThreeD:
                    TopDownCamera.gameObject.SetActive(false);
                    ThirdPersonCamera.gameObject.SetActive(true);
                    break;
            }
        }

        public BaseInputView CreateInputView<T>() where T : BaseInputView
        {
            var newInputView = new GameObject("InputView").AddComponent<T>();
            var playerInput = newInputView.AddComponent<PlayerInput>();

            playerInput.actions = PlayerInputAsset;
            playerInput.defaultActionMap = PlayerInputAsset.actionMaps[0].name;
            
            newInputView.PlayerInput = playerInput;
            newInputView.transform.SetParent(GameObject.Find("Views").transform);
            
            InputView = newInputView;
            
            return InputView;
        }
    }
}