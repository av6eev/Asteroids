using Game;
using Game.Input;
using Game.Scene;
using Game.Ship;
using Global;
using Global.Dialogs.Base;
using Global.Pulls.Base;
using Global.Save;
using Global.UI;

namespace Utilities
{
    public class GameEnvironment
    {
        public GlobalView GlobalView { get; }
        public GameSceneView GameSceneView { get; set; }
        
        public GameSpecifications Specifications { get; }
        public ScenesManager ScenesManager { get; }
        public UpdatersEngine UpdatersEngine { get; }
        public UpdatersEngine FixedUpdatersEngine { get; }
        public PullsData PullsData { get; }
        
        public ShipModel ShipModel { get; set; }
        public GameModel GameModel { get; set; }
        public GlobalUIModel GlobalUIModel { get; }
        public DialogsModel DialogsModel { get; set; }
        public InputModel InputModel { get; set; }
        public SaveModel SaveModel { get; set; }

        public GameEnvironment(GameSpecifications specifications,
            GlobalView globalView,
            ScenesManager scenesManager,
            UpdatersEngine updatersEngine,
            UpdatersEngine fixedUpdatersEngine,
            GlobalUIModel globalUIModel,
            PullsData pullsData)
        {
            Specifications = specifications;
            GlobalView = globalView;
            ScenesManager = scenesManager;
            UpdatersEngine = updatersEngine;
            FixedUpdatersEngine = fixedUpdatersEngine;
            GlobalUIModel = globalUIModel;
            PullsData = pullsData;
        }
    }
}