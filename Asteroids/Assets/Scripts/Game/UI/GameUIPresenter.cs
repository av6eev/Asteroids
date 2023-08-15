using Game.UI.Distance;
using Game.UI.EndScreen;
using Game.UI.Health;
using Game.UI.Money;
using Game.UI.Score;
using Global;
using UnityEngine;
using Utilities;

namespace Game.UI
{
    public class GameUIPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly GameUIModel _model;
        private readonly GameUIView _view;

        private readonly PresentersEngine _presenters = new();
        
        public GameUIPresenter(GlobalEnvironment environment, GameUIModel model, GameUIView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _view.EndScreenView.ChangeVisibility(false);
            
            CreateNecessaryData();
        }

        public void Deactivate()
        {
            _presenters.Deactivate();
            _presenters.Clear();
            
            Debug.Log(nameof(GameUIPresenter) + " deactivated!");
        }

        private void CreateNecessaryData()
        {
            _presenters.Add(new ScorePresenter(_environment, _model.ScoreModel, _view.ScoreView));
            _presenters.Add(new DistancePresenter(_environment, _model.DistanceModel, _view.DistanceView));
            _presenters.Add(new MoneyPresenter(_environment, _model.MoneyModel, _view.MoneyView));
            _presenters.Add(new HealthPresenter(_environment, _view.HealthView));
            _presenters.Add(new EndScreenPresenter(_environment, _view.EndScreenView));

            _presenters.Activate();
        }
    }
}