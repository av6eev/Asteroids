using Game;
using Game.Entities.Asteroids;
using Game.Entities.Ship.Base;
using Game.Input;
using Game.Scene;
using Global.Dialogs.Base;
using Global.Player;
using Global.Pulls.Base;
using Global.Save;
using Global.Sound;
using Global.UI;
using Utilities.Game;
using Utilities.Interfaces;

namespace Global
{
    public class GlobalEnvironment
    {
        public GlobalView GlobalView { get; }
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
            GlobalView globalView,
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