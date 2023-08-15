using Global;
using Utilities;

namespace Game.UI.EndScreen
{
    public class EndScreenPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly EndScreenView _view;

        public EndScreenPresenter(GlobalEnvironment environment, EndScreenView view)
        {
            _environment = environment;
            _view = view;
        }
        
        public void Activate()
        {
            _view.MainMenuButton.onClick.AddListener(EndGame);

            _environment.GameModel.OnEnded += Show;
        }

        public void Deactivate()
        {
            _view.MainMenuButton.onClick.RemoveListener(EndGame);
            
            _environment.GameModel.OnEnded -= Show;
        }

        private void Show()
        {
            var gameModel = _environment.GameModel;
            
            _view.ChangeVisibility(true);
            _view.SetData(gameModel.CurrentDistance, gameModel.CurrentScore, gameModel.CalculateGainedMoney());
        }

        private void EndGame()
        {
            _environment.GameModel.Close();
        }
    }
}