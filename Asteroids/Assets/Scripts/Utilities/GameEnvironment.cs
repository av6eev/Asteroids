using Global.Scene;

namespace Utilities
{
    public class GameEnvironment
    {
        public GlobalSceneView GlobalSceneView { get; }
        public ScenesManager ScenesManager { get; }

        public GameEnvironment(GlobalSceneView globalSceneView, ScenesManager scenesManager)
        {
            GlobalSceneView = globalSceneView;
            ScenesManager = scenesManager;
        }
    }
}