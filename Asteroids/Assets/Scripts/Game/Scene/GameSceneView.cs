using Game.Base;
using Game.UI;
using Game.UI.Base;
using UnityEngine;
using Utilities.BaseClasses;

namespace Game.Scene
{
    public class GameSceneView : BaseSceneView, IGameSceneView
    {
        [field: SerializeField] public GameView GameViewGo { get; private set; }
        [field: SerializeField] public GameUIView GameUIViewGo { get; private set; }

        public IGameView GameView => GameViewGo;
        public IGameUIView GameUIView => GameUIViewGo;
    }
}