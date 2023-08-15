using Game.Ship.Bullet;
using Global;
using Global.Pulls.Base;
using UnityEngine;
using Utilities;

namespace Game.Asteroids.Asteroid
{
    public class AsteroidPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly AsteroidModel _model;
        private readonly AsteroidView _view;

        public AsteroidPresenter(GlobalEnvironment environment, AsteroidModel model, AsteroidView view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            _view.SetPosition(_model.Position);
            
            _model.OnUpdate += Update;
            _view.OnCollision += CalculateDamage;
        }

        public void Deactivate()
        {
            _model.OnUpdate -= Update;
            _view.OnCollision -= CalculateDamage;
            
            Debug.Log(nameof(AsteroidPresenter) + " deactivated!");
        }

        private void CalculateDamage(string otherGoTag, BasePullElementView bulletView)
        {
            switch (otherGoTag)
            {
                case TagsHelper.AsteroidTag:
                    break;
                case TagsHelper.BulletTag:
                    _model.Health -= _environment.ShipModel.ShootModel.GetByValue((BulletView)bulletView).Damage;

                    ((BulletView)bulletView).Bump(_model);
                    
                    if (_model.Health <= 0)
                    {
                        _environment.AsteroidsModel.DestroyAsteroid(_model, false);    
                    }
                    break;
                case TagsHelper.ShipTag:
                    if (!_environment.ShipModel.IsImmune)
                    {
                        _environment.ShipModel.ApplyDamage();
                        _environment.AsteroidsModel.DestroyAsteroid(_model, false);    
                    }
                    break;
            }
        }

        private void Update(float deltaTime)
        {
            Move(deltaTime);
            Rotate(deltaTime);
        }
        
        private void Move(float deltaTime)
        {
            var multiplier = _model.Direction * (_model.Specification.Speed * deltaTime);
            
            _model.Position = _view.Move(multiplier);
        }

        private void Rotate(float deltaTime)
        {
            _view.Rotate(deltaTime);
        }
    }
}