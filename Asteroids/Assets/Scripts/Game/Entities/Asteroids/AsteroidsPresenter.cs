using System.Collections.Generic;
using System.Linq;
using Game.Entities.Asteroids.Asteroid;
using Game.Entities.Asteroids.Asteroid.Base;
using Game.Entities.Asteroids.Base;
using Game.Factories.Asteroid;
using Game.Factories.Asteroid.Base;
using Global;
using Global.Base;
using Specifications.Asteroids;
using Specifications.Asteroids.Base;
using Specifications.GameDifficulties;
using Utilities.Engines;
using Utilities.Enums;
using Utilities.Interfaces;
using Random = UnityEngine.Random;

namespace Game.Entities.Asteroids
{
    public class AsteroidsPresenter : IPresenter
    {
        private readonly IGlobalEnvironment _environment;
        private readonly IAsteroidsModel _model;

        private readonly Dictionary<IAsteroidModel, AsteroidPresenter> _asteroidsPresenters = new();
        private readonly List<IAsteroidModel> _inActiveAsteroids = new();

        private BaseAsteroidModelFactory _asteroidModelFactory = new AsteroidModel2DFactory();
        
        private Timer _spawnTimer;
        private bool _isPaused;

        public AsteroidsPresenter(IGlobalEnvironment environment, IAsteroidsModel model)
        {
            _environment = environment;
            _model = model;
        }
        
        public void Activate()
        {
            _spawnTimer = new Timer(_model.SpawnRate, true);
            _environment.TimersEngine.Add(_spawnTimer);
            
            _spawnTimer.OnTick += DefineNewAsteroid;
            
            _model.OnUpdate += Update;
            _model.OnAsteroidDestroyed += DestroyAsteroid;
            
            _environment.GameModel.OnDifficultyIncreased += UpdateModifiers;
            _environment.GameModel.OnDimensionChanged += RecreateActiveAsteroids;
        }

        public void Deactivate()
        {
            foreach (var presenter in _asteroidsPresenters.Values)
            {
                presenter.Deactivate();
            }
            
            _asteroidsPresenters.Clear();
            _inActiveAsteroids.Clear();
            
            _spawnTimer.OnTick -= DefineNewAsteroid;
            
            _model.OnUpdate -= Update;
            _model.OnAsteroidDestroyed -= DestroyAsteroid;
            
            _environment.GameModel.OnDifficultyIncreased -= UpdateModifiers;
            _environment.GameModel.OnDimensionChanged -= RecreateActiveAsteroids;
        }

        private void RecreateActiveAsteroids()
        {
            _isPaused = true;

            var tempActiveModels = _model.GetActiveAsteroids();

            _model.ResetActiveAsteroids();
            _inActiveAsteroids.Clear();

            foreach (var presenter in _asteroidsPresenters.Values)
            {
                presenter.Deactivate();
            }

            _asteroidsPresenters.Clear();

            _asteroidModelFactory = _environment.GameModel.CurrentDimension switch
            {
                CameraDimensionsTypes.TwoD => new AsteroidModel2DFactory(),
                CameraDimensionsTypes.ThreeD => new AsteroidModel3DFactory(),
                _ => _asteroidModelFactory
            };

            foreach (var model in tempActiveModels.Select(asteroid => _asteroidModelFactory.Create(asteroid.Key)).Where(newModel => newModel != null).ToList())
            {
                var position = model.GetPositionWithOffset(0, 0);
                
                CreateAsteroid(model.Specification, position.Item1, position.Item2);
            }

            _isPaused = false;
        }

        private void UpdateModifiers(GameDifficultySpecification difficultySpecification)
        {
            _model.UpdateModifiers(difficultySpecification.AsteroidsSpawnRateShift, difficultySpecification.AsteroidsSpeedShift);
            
            _spawnTimer.Reset();
            _spawnTimer.ChangeGivenTime(_model.SpawnRate);
        }

        private void Update(float deltaTime)
        {
            if (_isPaused) return;
            
            foreach (var model in _inActiveAsteroids)
            {
                DestroyAsteroid(model, true, false);
            }
            
            _inActiveAsteroids.Clear();

            foreach (var model in _model.GetActiveAsteroids().Keys)
            {
                if (model.CheckIntersects(_environment.GameModel.ZoneLimits))
                {
                    model.Update(deltaTime);
                    continue;
                }
                
                if (!_inActiveAsteroids.Contains(model))
                {
                    _inActiveAsteroids.Add(model);
                }
            }
        }

        private void CreateAsteroid(IAsteroidSpecification specification, float horizontalPosition, float forwardPosition)
        {
            var view = _environment.PullsModel.AsteroidsPulls[specification.Type].TryGetElement(); 
            var model = _asteroidModelFactory.Create(specification, _model.SpeedShift);
            
            if (model == null) return;
            
            model.SetPosition(horizontalPosition, forwardPosition);

            var presenter = new AsteroidPresenter(_environment, model, view);
            presenter.Activate();

            _asteroidsPresenters.Add(model, presenter);
            _model.AddActiveAsteroid(model, view);
        }

        private void DestroyAsteroid(IAsteroidModel model, bool byBorder, bool byShip)
        {
            _asteroidsPresenters[model].Deactivate();
            _asteroidsPresenters.Remove(model);

            TryCreateChildrenOnDestroyParent(model, byBorder, byShip);
            
            _environment.PullsModel.AsteroidsPulls[model.Specification.Type].PutBack(_model.GetByKey(model));
            
            _model.RemoveActiveAsteroid(model);
        }

        private void TryCreateChildrenOnDestroyParent(IAsteroidModel model, bool byBorder, bool byShip)
        {
            var subAsteroidsOnDestroy = model.Specification.SubAsteroidsCollection.SubAsteroidsOnDestroy;
            
            if (byBorder || byShip || subAsteroidsOnDestroy.Count == 0) return;
            
            foreach (var specification in subAsteroidsOnDestroy.Select(item => item.Get()))
            {
                var offset = Random.Range(-7f, 7f);
                var newPosition = model.GetPositionWithOffset(offset, offset);
                
                CreateAsteroid(specification, newPosition.Item1, newPosition.Item2);
            }
        }

        private void DefineNewAsteroid()
        {
            var randomChance = Random.Range(0f, 1f);
            var randomType = AsteroidsTypes.Default;
            var zoneLimits = _environment.GameModel.ZoneLimits;
            var horizontalOffset = Random.Range(zoneLimits.LeftSide + 2, zoneLimits.RightSide - 2);
            var forwardOffset = zoneLimits.TopSide - 3f;

            if (randomChance < _model.Specifications[AsteroidsTypes.Fire].ChanceToSpawn)
            {
                randomType = AsteroidsTypes.Fire;
            }
            
            if (randomChance > _model.Specifications[AsteroidsTypes.Fire].ChanceToSpawn && randomChance < _model.Specifications[AsteroidsTypes.Big].ChanceToSpawn)
            {
                randomType = AsteroidsTypes.Big;
            }
            
            if (randomChance > _model.Specifications[AsteroidsTypes.Big].ChanceToSpawn && randomChance < _model.Specifications[AsteroidsTypes.Medium].ChanceToSpawn)
            {
                randomType = AsteroidsTypes.Medium;
            }
            
            if (randomChance > _model.Specifications[AsteroidsTypes.Medium].ChanceToSpawn && randomChance < _model.Specifications[AsteroidsTypes.Small].ChanceToSpawn || randomChance > _model.Specifications[AsteroidsTypes.Small].ChanceToSpawn)
            {
                randomType = AsteroidsTypes.Small;
            }
            
            CreateAsteroid(_model.Specifications[randomType], horizontalOffset, forwardOffset);
        }
    }
}