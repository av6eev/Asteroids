using Utilities;

namespace Global.Player
{
    public class PlayerPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly PlayerModel _model;

        public PlayerPresenter(GlobalEnvironment environment, PlayerModel model)
        {
            _environment = environment;
            _model = model;
        }
        
        public void Activate()
        {
        }

        public void Deactivate()
        {
            
        }
    }
}