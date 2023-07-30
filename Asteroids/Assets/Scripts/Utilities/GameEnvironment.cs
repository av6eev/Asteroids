using Game;
using Game.Input;
using Game.Scene;
using Game.Ship;
using Global;
using Global.UI;

namespace Utilities
{
    public class GameEnvironment
    {
        public GlobalView GlobalView { get; }
        public GameSceneView GameSceneView { get; set; }
        
        public GameSpecifications Specifications { get; }
        public ScenesManager ScenesManager { get; }
        public SystemsEngine SystemsEngine { get; }
        public SystemsEngine FixedSystemsEngine { get; }
        
        public ShipModel ShipModel { get; set; }
        public GameModel GameModel { get; set; }
        public GlobalUIModel GlobalUIModel { get; }
        public InputModel InputModel { get; set; }

        public GameEnvironment(GameSpecifications specifications, GlobalView globalView, ScenesManager scenesManager, SystemsEngine systemsEngine, SystemsEngine fixedSystemsEngine, GlobalUIModel globalUIModel)
        {
            Specifications = specifications;
            GlobalView = globalView;
            ScenesManager = scenesManager;
            SystemsEngine = systemsEngine;
            FixedSystemsEngine = fixedSystemsEngine;
            GlobalUIModel = globalUIModel;
        }
    }
}