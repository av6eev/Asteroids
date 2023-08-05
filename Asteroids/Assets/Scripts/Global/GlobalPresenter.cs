using Global.Dialogs.Base;
using Global.UI;
using UnityEngine;
using Utilities;

namespace Global
{
    public class GlobalPresenter : MonoBehaviour
    {
        [SerializeField] private GlobalView GlobalView;
        
        private GameEnvironment _environment;
        private readonly PresentersEngine _globalPresenters = new();

        private void Start()
        {
            _environment = new GameEnvironment(
                new GameSpecifications(GlobalView.SpecificationsCollection), 
                GlobalView,
                new ScenesManager(),
                new SystemsEngine(),
                new SystemsEngine(),
                new GlobalUIModel());
            _environment.DialogsModel = new DialogsModel(_environment.Specifications);
            
            _globalPresenters.Add(new GlobalUIPresenter(_environment, _environment.GlobalUIModel, GlobalView.GlobalUIView));
            _globalPresenters.Add(new DialogsPresenter(_environment, _environment.DialogsModel, GlobalView.DialogsView));
            _globalPresenters.Activate();
        }

        private void Update()
        {
            _environment.SystemsEngine.Update(_environment);
        }

        private void FixedUpdate()
        {
            _environment.FixedSystemsEngine.Update(_environment);
        }
    }
}
