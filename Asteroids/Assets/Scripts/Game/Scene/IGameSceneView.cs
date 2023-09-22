using Game.Base;
using Game.UI.Base;

namespace Game.Scene
{
    public interface IGameSceneView
    {
        IGameView GameView { get; }
        IGameUIView GameUIView { get; }
    }
}