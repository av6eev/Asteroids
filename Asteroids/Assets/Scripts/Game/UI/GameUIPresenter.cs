using Game.UI.Base;
using Game.UI.Difficulty;
using Game.UI.Distance;
using Game.UI.EndScreen;
using Game.UI.Health;
using Game.UI.Money;
using Game.UI.Score;
using Global;
using Utilities.Engines;
using Utilities.Interfaces;

namespace Game.UI
{
    public class GameUIPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly IGameUIView _view;

        private readonly PresentersEngine _presenters = new();
        private int _cameraChangeCounter;
        
        public GameUIPresenter(GlobalEnvironment environment, IGameUIView view)
        {
            _environment = environment;
            _view = view;
        }
        
        public void Activate()
        {
            CreateNecessaryData();
            
            _view.InitializeButtonsSubscriptions();
            _view.OnCameraChanged += ChangeCameraView;

            _environment.GameModel.OnEnded += HideElements;
        }

        public void Deactivate()
        {
            _presenters.Deactivate();
            _presenters.Clear();
            
            _view.OnCameraChanged -= ChangeCameraView;
            _view.DisposeButtonsSubscriptions();
            
            _environment.GameModel.OnEnded -= HideElements;
        }

        private void HideElements() => _view.HideElementsAfterEnd();

        private void ChangeCameraView()
        {
            _cameraChangeCounter++;
            
            _environment.GameModel.ChangeDimension(_cameraChangeCounter % 2);
        }

        private void CreateNecessaryData()
        {
            _presenters.Add(new ScorePresenter(_environment, _view.ScoreView));
            _presenters.Add(new DistancePresenter(_environment, _view.DistanceView));
            _presenters.Add(new MoneyPresenter(_environment, _view.MoneyView));
            _presenters.Add(new DifficultyPresenter(_environment, _view.DifficultyView));
            _presenters.Add(new HealthPresenter(_environment, _view.HealthView));
            _presenters.Add(new EndScreenPresenter(_environment, _view.EndScreenView));

            _presenters.Activate();
        }
    }
}