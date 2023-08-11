using Game.Ship.Move;
using Game.Ship.Shoot;
using Utilities;

namespace Game.Ship
{
    public class ShipPresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly ShipModel _model;
        private readonly ShipView _view;

        private readonly PresentersEngine _presenters = new();
        
        public ShipPresenter(GameEnvironment environment, ShipModel model, ShipView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            CreateNecessaryData();
        }

        private void CreateNecessaryData()
        {
            var specification = _model.Specification;
            _model.ShootModel = new ShipShootModel(specification.Count, specification.ReloadTime, specification.ShotRate, specification.IsAutomatic, specification.BulletPrefab.Speed);
            _model.MoveModel = new ShipMoveModel(specification.Speed);
            
            _presenters.Add(new ShipMovePresenter(_environment, _model.MoveModel));
            _presenters.Add(new ShipShootPresenter(_environment, _model.ShootModel));
            
            _presenters.Activate();
            
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.ShipMove, new ShipMoveUpdater());
            _environment.FixedUpdatersEngine.Add(UpdatersTypes.ShipShoot, new ShipShootUpdater());
        }

        public void Deactivate()
        {
            _presenters.Deactivate();
            _presenters.Clear();
            
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.ShipMove);
            _environment.FixedUpdatersEngine.Remove(UpdatersTypes.ShipShoot);
        }
    }
}