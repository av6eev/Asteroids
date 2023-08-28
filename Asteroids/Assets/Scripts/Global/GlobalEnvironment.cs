using Game;
using Game.Entities.Asteroids;
using Game.Entities.Ship;
using Game.Input;
using Game.Scene;
using Global.Dialogs.Base;
using Global.Player;
using Global.Pulls.Base;
using Global.Save;
using Global.UI;
using Utilities;

namespace Global
{
    public class GlobalEnvironment
    {
        public GlobalView GlobalView { get; }
        public GameSceneView GameSceneView { get; set; }
        
        public GameSpecifications Specifications { get; }
        public ScenesManager ScenesManager { get; }
        public UpdatersEngine UpdatersEngine { get; }
        public UpdatersEngine FixedUpdatersEngine { get; }
        public UpdatersEngine LateUpdatersEngine { get; }
        public TimersEngine TimersEngine { get; }
        public PullsData PullsData { get; set; }

        public GlobalUIModel GlobalUIModel { get; }
        public PlayerModel PlayerModel { get; }
        public ShipModel ShipModel { get; set; }
        public GameModel GameModel { get; set; }
        public DialogsModel DialogsModel { get; set; }
        public InputModel InputModel { get; set; }
        public SaveModel SaveModel { get; set; }
        public AsteroidsModel AsteroidsModel { get; set; }

        public GlobalEnvironment(GameSpecifications specifications,
            GlobalView globalView,
            ScenesManager scenesManager,
            UpdatersEngine updatersEngine,
            UpdatersEngine fixedUpdatersEngine,
            UpdatersEngine lateUpdatersEngine,
            TimersEngine timersEngine,
            GlobalUIModel globalUIModel,
            PlayerModel playerModel)
        {
            Specifications = specifications;
            GlobalView = globalView;
            ScenesManager = scenesManager;
            UpdatersEngine = updatersEngine;
            FixedUpdatersEngine = fixedUpdatersEngine;
            LateUpdatersEngine = lateUpdatersEngine;
            TimersEngine = timersEngine;
            GlobalUIModel = globalUIModel;
            PlayerModel = playerModel;
        }
    }
}