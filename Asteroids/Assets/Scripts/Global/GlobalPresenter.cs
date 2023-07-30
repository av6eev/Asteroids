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
            _environment = new GameEnvironment(new GameSpecifications(GlobalView.SpecificationsCollection), GlobalView, new ScenesManager(), new SystemsEngine(), new SystemsEngine(), new GlobalUIModel());
            
            _globalPresenters.Add(new GlobalUIPresenter(_environment, _environment.GlobalUIModel, GlobalView.GlobalUIView));
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
