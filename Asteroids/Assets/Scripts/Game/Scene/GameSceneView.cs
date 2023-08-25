using Game.Input;
using Game.UI;
using UnityEngine;
using Utilities;

namespace Game.Scene
{
    public class GameSceneView : BaseSceneView
    {
        [field: SerializeField] public Camera TopDownCamera { get; private set; }
        [field: SerializeField] public Camera ThirdPersonCamera { get; private set; }
        [field: SerializeField] public InputView InputView { get; private set; }
        [field: SerializeField] public GameView GameView { get; private set; }
        [field: SerializeField] public GameUIView GameUIView { get; private set; }
    }
}