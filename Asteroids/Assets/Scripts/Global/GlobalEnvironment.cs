using Game;
using Game.Entities.Asteroids.Base;
using Game.Entities.Ship.Base;
using Game.Input.Base;
using Game.Scene;
using Global.Dialogs.Base;
using Global.Player;
using Global.Pulls.Base.PullData;
using Global.Save;
using Global.Scene;
using Global.Sound;
using Global.UI;
using Utilities.Game;
using Utilities.Interfaces;

namespace Global
{
    public class GlobalEnvironment
    {
        public GlobalSceneView GlobalView { get; }
        public SoundManager SoundManager { get; }
        public GameSceneView GameSceneView { get; set; }

        public GameSpecifications Specifications { get; }
        public IScenesManager ScenesManager { get; }
        public IUpdatersEngine UpdatersEngine { get; }
        public IUpdatersEngine FixedUpdatersEngine { get; }
        public IUpdatersEngine LateUpdatersEngine { get; }
        public ITimersEngine TimersEngine { get; }
        public IPullsData PullsData { get; set; }

        public IGlobalUIModel GlobalUIModel { get; }
        public IPlayerModel PlayerModel { get; }
        public IShipModel ShipModel { get; set; }
        public IGameModel GameModel { get; set; }
        public IDialogsModel DialogsModel { get; set; }
        public IInputModel InputModel { get; set; }
        public ISaveModel SaveModel { get; set; }
        public IAsteroidsModel AsteroidsModel { get; set; }

        public GlobalEnvironment(GameSpecifications specifications,
            GlobalSceneView globalView,
            IScenesManager scenesManager,
            IUpdatersEngine updatersEngine,
            IUpdatersEngine fixedUpdatersEngine,
            IUpdatersEngine lateUpdatersEngine,
            ITimersEngine timersEngine,
            IGlobalUIModel globalUIModel,
            IPlayerModel playerModel)
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
            SoundManager = globalView.SoundManager.Instance;
        }
    }
}