using Game.UI.Difficulty.Base;
using Global;
using Global.Base;
using Specifications.GameDifficulties;
using Utilities.Interfaces;

namespace Game.UI.Difficulty
{
    public class DifficultyPresenter : IPresenter
    {
        private readonly IGlobalEnvironment _environment;
        private readonly IDifficultyView _view;

        public DifficultyPresenter(IGlobalEnvironment environment, IDifficultyView view)
        {
            _environment = environment;
            _view = view;
        }
        
        public void Activate() => _environment.GameModel.OnDifficultyIncreased += UpdateView;

        public void Deactivate() => _environment.GameModel.OnDifficultyIncreased -= UpdateView;

        private void UpdateView(GameDifficultySpecification specification) => _view.UpdateDifficulty((int)specification.Stage);
    }
}