using System;
using Global.Dialogs;
using Global.Player;
using Global.Save;
using Global.Scene;
using Global.UI;
using UnityEngine;
using Utilities;
using Utilities.Engines;
using Utilities.Game;

namespace Global
{
    public class GlobalPresenter : MonoBehaviour
    {
        [field: SerializeField] private GlobalSceneView GlobalView { get; set; }
        [field: NonSerialized] private GlobalEnvironment Environment { get; set; }
        [field: NonSerialized] private PresentersEngine GlobalPresenters { get; } = new();

        private void Start()
        {
            Environment = new GlobalEnvironment(
                new GameSpecifications(GlobalView.SpecificationsCollection), 
                GlobalView,
                new ScenesManager(),
                new UpdatersEngine(),
                new UpdatersEngine(),
                new UpdatersEngine(),
                new TimersEngine(),
                new GlobalUIModel(),
                new PlayerModel())
            {
                DialogsModel = new DialogsModel(),
                SaveModel = new SaveModel()
            };

            GlobalPresenters.Add(new GlobalUIPresenter(Environment, Environment.GlobalUIModel, GlobalView.GlobalUIView));
            GlobalPresenters.Add(new DialogsPresenter(Environment, Environment.DialogsModel, GlobalView.DialogsView));
            GlobalPresenters.Add(new PlayerPresenter(Environment, Environment.PlayerModel));
            GlobalPresenters.Add(new SavePresenter(Environment, Environment.SaveModel));
            GlobalPresenters.Activate();
            
            Environment.SaveModel.Deserialize();
        }

        private void Update()
        {
            Environment.UpdatersEngine.Update(Environment);
            Environment.TimersEngine.Update(Time.deltaTime);
        }

        private void FixedUpdate() => Environment.FixedUpdatersEngine.Update(Environment);

        private void LateUpdate() => Environment.LateUpdatersEngine.Update(Environment);

        public void OnApplicationQuit()
        {
            GlobalPresenters.Deactivate();
            GlobalPresenters.Clear();
        }
    }
}
