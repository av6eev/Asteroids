using System;
using Game.Entities.Asteroids;
using Global.Factories.Pulls.Asteroids;
using Global.Factories.Pulls.Asteroids.Base;
using Global.Factories.Pulls.Bullets;
using Global.Factories.Pulls.Bullets.Base;
using Global.Factories.Pulls.Hits;
using Global.Factories.Pulls.Hits.Base;
using Global.Pulls.Asteroids;
using Global.Pulls.Base;
using Utilities.Enums;
using Utilities.Interfaces;

namespace Global.Pulls
{
    public class PullsPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly IPullsModel _model;
        private readonly IPullsViews _view;

        private BaseAsteroidsPullElementViewFactory _asteroidsPullElementViewFactory;
        private BaseBulletsPullElementViewFactory _bulletsPullElementViewFactory;
        private BaseHitsPullElementViewFactory _hitsPullElementViewFactory;

        public PullsPresenter(GlobalEnvironment environment, IPullsModel model, IPullsViews view)
        {
            _environment = environment;
            _model = model;
            _view = view;
        }
        
        public void Activate()
        {
            Initialize();

            _environment.GameModel.OnDimensionChanged += Reset;
        }

        public void Deactivate()
        {
            Dispose();
            
            _environment.GameModel.OnDimensionChanged -= Reset;
        }

        private void Initialize()
        {
            _asteroidsPullElementViewFactory = new AsteroidsPullElementView2DFactory();
            _bulletsPullElementViewFactory = new BulletsPullElementView2DFactory();
            _hitsPullElementViewFactory = new HitsPullElementView2DFactory();
            
            CreateAsteroidsPulls();
            CreateBulletsPull();
            CreateHitsPull();
        }

        private void Dispose() => _model.ClearAllData();

        private void Reset()
        {
            _model.ClearAllData();
            
            switch (_environment.GameModel.CurrentDimension)
            {
                case CameraDimensionsTypes.TwoD:
                    _asteroidsPullElementViewFactory = new AsteroidsPullElementView2DFactory();
                    _bulletsPullElementViewFactory = new BulletsPullElementView2DFactory();
                    _hitsPullElementViewFactory = new HitsPullElementView2DFactory();
                    break;
                case CameraDimensionsTypes.ThreeD:
                    _asteroidsPullElementViewFactory = new AsteroidsPullElementView3DFactory();
                    _bulletsPullElementViewFactory = new BulletsPullElementView3DFactory();
                    _hitsPullElementViewFactory = new HitsPullElementView3DFactory();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            CreateAsteroidsPulls();
            CreateBulletsPull();
            CreateHitsPull();
        }

        private void CreateAsteroidsPulls()
        {
            foreach (var pull in _model.AsteroidsPulls)
            {
                IAsteroidsPullView pullView = null;
                
                switch (pull.Key)
                {
                    case AsteroidsTypes.Default:
                        break;
                    case AsteroidsTypes.Small:
                        pullView = _view.SmallAsteroidsPullView;
                        pullView.ElementPrefab = _asteroidsPullElementViewFactory.GetSmall(_environment);
                        break;
                    case AsteroidsTypes.Medium:
                        pullView = _view.MediumAsteroidsPullView;
                        pullView.ElementPrefab = _asteroidsPullElementViewFactory.GetMedium(_environment);
                        break;
                    case AsteroidsTypes.Big:
                        pullView = _view.BigAsteroidsPullView;
                        pullView.ElementPrefab = _asteroidsPullElementViewFactory.GetBig(_environment);
                        break;
                    case AsteroidsTypes.Fire:
                        pullView = _view.FireAsteroidsPullView;
                        pullView.ElementPrefab = _asteroidsPullElementViewFactory.GetFire(_environment);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                
                pull.Value.CreatePull(pullView);
            }
        }

        private void CreateBulletsPull()
        {
            var bulletsPull = _view.BulletsPullView;
            
            bulletsPull.ElementPrefab = _bulletsPullElementViewFactory.Get(_environment);
            
            _model.BulletsPull.CreatePull(bulletsPull);  
        }

        private void CreateHitsPull()
        {
            var hitsPull = _view.HitsPullView;
            
            hitsPull.ElementPrefab = _hitsPullElementViewFactory.Get(_environment);
            
            _model.HitsPull.CreatePull(hitsPull);
        }
    }
}