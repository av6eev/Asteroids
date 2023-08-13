using Global.Dialogs.Base;
using Global.Pulls.Base;
using Global.Save;
using Global.UI;
using UnityEngine;
using Utilities;

namespace Global
{
    public class GlobalPresenter : MonoBehaviour
    {
        [SerializeField] private GlobalView GlobalView;
        
        private GlobalEnvironment _environment;
        private readonly PresentersEngine _globalPresenters = new();

        private void Start()
        {
            _environment = new GlobalEnvironment(
                new GameSpecifications(GlobalView.SpecificationsCollection), 
                GlobalView,
                new ScenesManager(),
                new UpdatersEngine(),
                new UpdatersEngine(),
                new TimersEngine(),
                new GlobalUIModel());
            
            _environment.DialogsModel = new DialogsModel(_environment.Specifications);
            _environment.SaveModel = new SaveModel();
            
            _globalPresenters.Add(new GlobalUIPresenter(_environment, _environment.GlobalUIModel, GlobalView.GlobalUIView));
            _globalPresenters.Add(new DialogsPresenter(_environment, _environment.DialogsModel, GlobalView.DialogsView));
            _globalPresenters.Add(new SavePresenter(_environment, _environment.SaveModel));
            _globalPresenters.Activate();
        }

        private void Update()
        {
            _environment.UpdatersEngine.Update(_environment);
            _environment.TimersEngine.Update(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _environment.FixedUpdatersEngine.Update(_environment);
        }
    }
}
