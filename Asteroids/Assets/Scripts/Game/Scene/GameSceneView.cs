using Game.Input;
using Game.UI;
using UnityEngine;
using Utilities.BaseClasses;
using Utilities.Enums;

namespace Game.Scene
{
    public class GameSceneView : BaseSceneView
    {
        [field: SerializeField] public Camera TopDownCamera { get; private set; }
        [field: SerializeField] public Camera ThirdPersonCamera { get; private set; }
        [field: SerializeField] public InputView InputView { get; private set; }
        [field: SerializeField] public GameView GameView { get; private set; }
        [field: SerializeField] public GameUIView GameUIView { get; private set; }

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
    }
}