using Game.Entities.Asteroids.Asteroid.Base;
using Game.Entities.Bullet.Base;
using Global;
using Global.Pulls.Base.PullElement;
using Global.Sound;
using Utilities.Helpers;
using Utilities.Interfaces;

namespace Game.Entities.Asteroids.Asteroid
{
    public class AsteroidPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly IAsteroidModel _model;
        private readonly IAsteroidView _view;
        
        private const float MOVE_FORWARD_MULTIPLIER = 30f;

        public AsteroidPresenter(GlobalEnvironment environment, IAsteroidModel model, IAsteroidView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _view.SetPosition(_model.Position);
            
            _model.OnUpdate += Update;
            _model.OnDestroy += Destroy;
            
            _view.OnTriggered += CalculateDamage;
        }

        public void Deactivate()
        {
            _model.OnUpdate -= Update;
            _model.OnDestroy -= Destroy;
            
            _view.OnTriggered -= CalculateDamage;
        }

        private void Destroy() => _environment.AsteroidsModel.DestroyAsteroid(_model, false, false);

        private void CalculateDamage(string otherGoTag, IPullElementView view)
        {
            switch (otherGoTag)
            {
                case TagsHelper.AsteroidTag:
                    break;
                case TagsHelper.BulletTag:
                    var bulletView = (IBulletView)view;
                    var bulletDamage = _environment.ShipModel.ShootModel.GetByValue(bulletView).Damage;

                    if (view != null)
                    {
                        bulletView.Bump(_model);
                    }

                    _model.ApplyDamage(bulletDamage);
                    break;
                case TagsHelper.ShipTag:
                    if (!_environment.ShipModel.IsImmune)
                    {
                        _environment.ShipModel.ApplyDamage(1);
                        _environment.AsteroidsModel.DestroyAsteroid(_model, false, true);    
                        _environment.SoundManager.Play(SoundsTypes.ShipHit);
                    }
                    break;
            }
        }

        private void Update(float deltaTime)
        {
            Move(deltaTime);
            Rotate(deltaTime);
        }
        
        private void Move(float deltaTime) => _model.UpdatePosition(_view.Move(_model.Direction * (_model.Speed * MOVE_FORWARD_MULTIPLIER * deltaTime)));

        private void Rotate(float deltaTime) => _view.Rotate(deltaTime);
    }
}