using Global.Scene;
using Global.UI;
using UnityEngine;
using Utilities;

namespace Global
{
    public class GlobalPresenter : MonoBehaviour
    {
        [SerializeField] private GlobalSceneView GlobalSceneView;
        
        private GameEnvironment _environment;
        private readonly PresentersEngine _globalPresenters = new();

        private void Start()
        {
            _environment = new GameEnvironment(GlobalSceneView, new ScenesManager(_environment));
            _globalPresenters.Add(new GlobalUIPresenter(_environment, GlobalSceneView.GlobalUIView));
            
            _globalPresenters.Activate();
        }

        private void Update()
        {
        
        }
    }
}
