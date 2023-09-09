using System.Collections.Generic;
using System.Linq;
using Game.Entities.Asteroids.Asteroid;
using Game.Entities.Asteroids.Asteroid.Base;
using Global;
using Specifications.Asteroids;
using Specifications.GameDifficulties;
using UnityEngine;
using Utilities.Engines;
using Utilities.Enums;
using Utilities.Interfaces;
using Random = UnityEngine.Random;

namespace Game.Entities.Asteroids
{
    public class AsteroidsPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly AsteroidsModel _model;

        private readonly Dictionary<IAsteroidModel, AsteroidPresenter> _asteroidsPresenters = new();
        private readonly List<IAsteroidModel> _inActiveAsteroids = new();
        
        private Timer _spawnTimer;
        private bool _isPaused;

        public AsteroidsPresenter(GlobalEnvironment environment, AsteroidsModel model)
        {
            _environment = environment;
            _model = model;
        }
        
        public void Activate()
        {
            CreateAsteroidsPulls();

            _spawnTimer = new Timer(_model.SpawnRate, true);
            _environment.TimersEngine.Add(_spawnTimer);
            
            _spawnTimer.OnTick += DefineNewAsteroid;
            
            _model.OnUpdate += Update;
            _model.OnAsteroidDestroyed += DestroyAsteroid;
            
            _environment.GameModel.OnDifficultyIncreased += UpdateModifiers;
            _environment.GameModel.OnDimensionChanged += ChangeActiveAsteroidViews;
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
            _environment.GameModel.OnDimensionChanged -= ChangeActiveAsteroidViews;
            
            Debug.Log(nameof(AsteroidsPresenter) + " deactivated!");
        }

        private void ChangeActiveAsteroidViews()
        {
            var tempList = new Dictionary<IAsteroidModel, BaseAsteroidView>();
            
            _isPaused = true;

            foreach (var asteroid in _model.GetActiveAsteroids())
            {
                var asteroidsPull3D = _environment.PullsData.AsteroidsPulls3D[asteroid.Key.Specification.Type];
                var asteroidsPull2D = _environment.PullsData.AsteroidsPulls2D[asteroid.Key.Specification.Type];
                var position = asteroid.Key.Position;
                BaseAsteroidView newView;
                Vector3 newPosition;
                
                switch (_environment.GameModel.CurrentDimension)
                {
                    case CameraDimensionsTypes.TwoD:
                        asteroidsPull3D.PutBack((AsteroidView3D)asteroid.Value);
                        newView = asteroidsPull2D.TryGetElement();
                        newPosition = new Vector3(position.x, position.z, 0);
                        break;
                    case CameraDimensionsTypes.ThreeD:
                        asteroidsPull2D.PutBack((AsteroidView2D)asteroid.Value);
                        newView = asteroidsPull3D.TryGetElement();
                        newPosition = new Vector3(position.x, 0, position.y);
                        break;
                    default:
                        newView = asteroid.Value;
                        newPosition = position;
                        break;
                }

                asteroid.Key.UpdatePosition(newPosition);
                tempList.Add(asteroid.Key, newView);
            }

            _model.ResetActiveAsteroids(tempList);

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

        private void CreateAsteroid(AsteroidSpecification specification, float horizontalPosition, float forwardPosition)
        {
            IAsteroidModel model = null;
            BaseAsteroidView view = null;
            
            switch (_environment.GameModel.CurrentDimension)
            {
                case CameraDimensionsTypes.TwoD:
                    model = new AsteroidModel2D(specification, _model.SpeedShift);
                    view = _environment.PullsData.AsteroidsPulls2D[specification.Type].TryGetElement();
                    break;
                case CameraDimensionsTypes.ThreeD:
                    model = new AsteroidModel3D(specification, _model.SpeedShift);
                    view = _environment.PullsData.AsteroidsPulls3D[specification.Type].TryGetElement();
                    break;
            }

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

            switch (_environment.GameModel.CurrentDimension)
            {
                case CameraDimensionsTypes.TwoD:
                    _environment.PullsData.AsteroidsPulls2D[model.Specification.Type].PutBack((AsteroidView2D)_model.GetByKey(model));
                    break;
                case CameraDimensionsTypes.ThreeD:
                    _environment.PullsData.AsteroidsPulls3D[model.Specification.Type].PutBack((AsteroidView3D)_model.GetByKey(model));
                    break;
            }
            
            _model.RemoveActiveAsteroid(model);
        }

        private void TryCreateChildrenOnDestroyParent(IAsteroidModel model, bool byBorder, bool byShip)
        {
            if (byBorder || byShip || model.Specification.SubAsteroidsOnDestroy.Count == 0) return;
            
            foreach (var specification in model.Specification.SubAsteroidsOnDestroy.Select(item => item.Specification))
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

        private void CreateAsteroidsPulls()
        {
            foreach (var pull in _environment.PullsData.AsteroidsPulls3D)
            {
                var pullView = _environment.GameSceneView.GameView.AsteroidsPullView3D.Find(item => item.Type == pull.Key);

                pullView.ElementPrefab = _model.Specifications[pull.Key].Prefab3D;
                pullView.Count = 13;
                
                pull.Value.CreatePull(pullView);
            }
            
            foreach (var pull in _environment.PullsData.AsteroidsPulls2D)
            {
                var pullView = _environment.GameSceneView.GameView.AsteroidsPullView2D.Find(item => item.Type == pull.Key);

                pullView.ElementPrefab = _model.Specifications[pull.Key].Prefab2D;
                pullView.Count = 13;
                
                pull.Value.CreatePull(pullView);
            }
        }
    }
}