using Game.CameraUpdater;
using Game.Ship.Bullet;
using Game.Ship.Bullet.Base;
using Global;
using Global.Pulls.Base;
using Utilities;

namespace Game.Asteroids.Asteroid
{
    public class AsteroidPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly AsteroidModel _model;
        private BaseAsteroidView _view;
        
        private const float MOVE_FORWARD_MULTIPLIER = 30f;

        public AsteroidPresenter(GlobalEnvironment environment, AsteroidModel model, BaseAsteroidView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _view.SetPosition(_model.Position);
            
            _model.OnUpdate += Update;
            _model.OnViewChanged += ChangeView;
            
            _view.OnTriggered += CalculateDamage;
        }

        public void Deactivate()
        {
            _model.OnUpdate -= Update;
            _model.OnViewChanged -= ChangeView;
            
            _view.OnTriggered -= CalculateDamage;
        }

        private void ChangeView(BaseAsteroidView newView) => _view = newView;

        private void CalculateDamage(string otherGoTag, BasePullElementView bulletView)
        {
            switch (otherGoTag)
            {
                case TagsHelper.AsteroidTag:
                    break;
                case TagsHelper.BulletTag:
                    BaseBulletView concreteBullet = _environment.GameModel.CurrentDimension switch
                    {
                        CameraDimensionsTypes.TwoD => (BulletView2D)bulletView,
                        CameraDimensionsTypes.ThreeD => (BulletView3D)bulletView,
                        _ => null
                    };
                    
                    var bulletDamage = _environment.ShipModel.ShootModel.GetByValue(concreteBullet).Damage;

                    if (concreteBullet != null)
                    {
                        concreteBullet.Bump(_model);
                    }

                    _model.Health -= bulletDamage;
                    
                    if (_model.Health <= 0)
                    {
                        _environment.AsteroidsModel.DestroyAsteroid(_model, false, false);    
                    }
                    break;
                case TagsHelper.ShipTag:
                    if (!_environment.ShipModel.IsImmune)
                    {
                        _environment.ShipModel.ApplyDamage();
                        _environment.AsteroidsModel.DestroyAsteroid(_model, false, true);    
                    }
                    break;
            }
        }

        private void Update(float deltaTime)
        {
            Move(deltaTime);
            Rotate(deltaTime);
        }
        
        private void Move(float deltaTime) => _model.Position = _view.Move(_model.Direction * (_model.Speed * MOVE_FORWARD_MULTIPLIER * deltaTime));

        private void Rotate(float deltaTime) => _view.Rotate(deltaTime);
    }
}