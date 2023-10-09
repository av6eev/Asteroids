using Game.Base;
using Game.Entities.Asteroids.Base;
using Game.Entities.Ship.Base;
using Game.Input.Base;
using Game.Scene;
using Game.Scene.Base;
using Global.Base;
using Global.Dialogs.Base;
using Global.Player.Base;
using Global.Pulls.Base;
using Global.Save.Base;
using Global.Scene;
using Global.UI.Base;
using Utilities.Game;
using Utilities.Interfaces;

namespace Global
{
    public class GlobalEnvironment : IGlobalEnvironment
    {
        public IGlobalSceneView GlobalSceneView { get; }
        public IGameSceneView GameSceneView { get; set; }

        public IGameSpecifications Specifications { get; }
        public IScenesManager ScenesManager { get; }
        public IUpdatersEngine UpdatersEngine { get; }
        public IUpdatersEngine FixedUpdatersEngine { get; }
        public IUpdatersEngine LateUpdatersEngine { get; }
        public ITimersEngine TimersEngine { get; }
        public IPullsModel PullsModel { get; set; }

        public IGlobalUIModel GlobalUIModel { get; }
        public IPlayerModel PlayerModel { get; }
        public IShipModel ShipModel { get; set; }
        public IGameModel GameModel { get; set; }
        public IDialogsModel DialogsModel { get; set; }
        public IInputModel InputModel { get; set; }
        public ISaveModel SaveModel { get; set; }
        public IAsteroidsModel AsteroidsModel { get; set; }

        public GlobalEnvironment(
            IGameSpecifications specifications,
            IGlobalSceneView globalView,
            IScenesManager scenesManager,
            IUpdatersEngine updatersEngine,
            IUpdatersEngine fixedUpdatersEngine,
            IUpdatersEngine lateUpdatersEngine,
            ITimersEngine timersEngine,
            IGlobalUIModel globalUIModel,
            IPlayerModel playerModel)
        {
            Specifications = specifications;
            GlobalSceneView = globalView;
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