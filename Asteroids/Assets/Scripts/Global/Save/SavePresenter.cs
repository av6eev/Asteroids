using Utilities;

namespace Global.Save
{
    public class SavePresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly SaveModel _model;

        public SavePresenter(GameEnvironment environment, SaveModel model)
        {
            _environment = environment;
            _model = model;
        }
        
        public void Activate()
        {
            _model.OnSave += SaveGame;
        }

        public void Deactivate()
        {
            _model.OnSave -= SaveGame;
        }
        
        private void SaveGame()
        {
            
        }
    }
}