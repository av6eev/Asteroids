using Global;
using Specifications.GameDifficulties;
using Utilities;
using Utilities.Interfaces;

namespace Game.UI.Difficulty
{
    public class DifficultyPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly DifficultyView _view;

        public DifficultyPresenter(GlobalEnvironment environment, DifficultyView view)
        {
            _environment = environment;
            _view = view;
        }
        
        public void Activate() => _environment.GameModel.OnDifficultyIncreased += UpdateView;

        public void Deactivate() => _environment.GameModel.OnDifficultyIncreased -= UpdateView;

        private void UpdateView(GameDifficultySpecification specification) => _view.UpdateDifficulty((int)specification.Stage);
    }
}