using Game.Base;
using Game.Entities.Asteroids.Base;
using Game.Entities.Ship.Base;
using Game.Input.Base;
using Game.Scene.Base;
using Global.Dialogs.Base;
using Global.Player.Base;
using Global.Pulls.Base;
using Global.Save.Base;
using Global.Scene;
using Global.UI.Base;
using Utilities.Game;
using Utilities.Interfaces;

namespace Global.Base
{
    public interface IGlobalEnvironment
    {
        IGlobalSceneView GlobalSceneView { get; }
        IGameSceneView GameSceneView { get; set; }
        IGameSpecifications Specifications { get; }
        IScenesManager ScenesManager { get; }
        IUpdatersEngine UpdatersEngine { get; }
        IUpdatersEngine FixedUpdatersEngine { get; }
        IUpdatersEngine LateUpdatersEngine { get; }
        ITimersEngine TimersEngine { get; }
        IPullsModel PullsModel { get; set; }
        IGlobalUIModel GlobalUIModel { get; }
        IPlayerModel PlayerModel { get; }
        IShipModel ShipModel { get; set; }
        IGameModel GameModel { get; set; }
        IDialogsModel DialogsModel { get; set; }
        IInputModel InputModel { get; set; }
        ISaveModel SaveModel { get; set; }
        IAsteroidsModel AsteroidsModel { get; set; }
    }
}