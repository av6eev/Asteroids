using Game.Input;
using Game.Score;
using Game.UI;
using UnityEngine;
using Utilities;

namespace Game.Scene
{
    public class GameSceneView : BaseSceneView
    {
        [field: SerializeField] public Camera MainCamera { get; private set; }
        [field: SerializeField] public InputView InputView { get; private set; }
        [field: SerializeField] public GameView GameView { get; private set; }
        [field: SerializeField] public GameUIView GameUIView { get; private set; }
    }
}