using UnityEngine;
using Utilities;

namespace Game.UI
{
    public class GameUIPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly GameUIModel _model;
        private readonly GameUIView _view;

        public GameUIPresenter(GlobalEnvironment environment, GameUIModel model, GameUIView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            SetStartedHealth(_environment.ShipModel.Health);
            
            _environment.ShipModel.OnDamageApplied += UpdateHealthBar;
        }

        private void SetStartedHealth(int maxHealth)
        {
            _view.SetStartedHealth(maxHealth);
        }

        public void Deactivate()
        {
            _environment.ShipModel.OnDamageApplied -= UpdateHealthBar;

            Debug.Log(nameof(GameUIPresenter) + " deactivated!");
        }

        private void UpdateHealthBar()
        {
            _view.UpdateHealthBar();
        }
    }
}