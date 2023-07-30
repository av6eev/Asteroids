using Utilities;

namespace Game.UI
{
    public class GameUIPresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly GameUIView _view;

        public GameUIPresenter(GameEnvironment environment, GameUIView view)
        {
            _environment = environment;
            _view = view;
        }
        
        public void Activate()
        {
            
        }

        public void Deactivate()
        {
            
        }
    }
}