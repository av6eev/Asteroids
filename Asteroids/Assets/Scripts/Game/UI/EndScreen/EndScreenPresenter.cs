using Game.UI.EndScreen.Base;
using Global;
using Utilities.Interfaces;

namespace Game.UI.EndScreen
{
    public class EndScreenPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly IEndScreenView _view;

        public EndScreenPresenter(GlobalEnvironment environment, IEndScreenView view)
        {
            _environment = environment;
            _view = view;
        }
        
        public void Activate()
        {
            _view.InitializeButtonsSubscriptions();
            _view.OnMainMenuClicked += EndGame;

            _environment.GameModel.OnEnded += Show;
        }

        public void Deactivate()
        {
            _view.OnMainMenuClicked -= EndGame;
            _view.DisposeButtonsSubscriptions();
            
            _environment.GameModel.OnEnded -= Show;
        }

        private void Show()
        {
            var gameModel = _environment.GameModel;
            
            _view.SetData(gameModel.CurrentDistance, gameModel.CurrentScore, gameModel.CalculateGainedMoney());
            _view.Show();
        }

        private void EndGame() => _environment.GameModel.Close();
    }
}