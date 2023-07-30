using Game.Input;
using Game.Ship;
using UnityEngine;
using Utilities;

namespace Game.Scene
{
    public class GameSceneView : BaseSceneView
    {
        [field: SerializeField] public Camera MainCamera { get; protected set; }
        [field: SerializeField] public InputView InputView { get; protected set; }
        [field: SerializeField] public GameView GameView { get; protected set; }
    }
}