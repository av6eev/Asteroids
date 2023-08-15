using System.Collections.Generic;
using System.Linq;
using Game.Asteroids.Asteroid;
using Global;
using Specifications.Asteroids;
using UnityEngine;
using Utilities;
using Random = UnityEngine.Random;

namespace Game.Asteroids
{
    public class AsteroidsPresenter : IPresenter
    {
        private readonly GlobalEnvironment _environment;
        private readonly AsteroidsModel _model;

        private readonly Dictionary<AsteroidModel, AsteroidPresenter> _asteroidsPresenters = new();
        private readonly List<AsteroidModel> _inActiveAsteroids = new();
        
        private Timer _spawnTimer;

        public AsteroidsPresenter(GlobalEnvironment environment, AsteroidsModel model)
        {
            _environment = environment;
            _model = model;
        }
        
        public void Activate()
        {
            CreateAsteroidsPulls();

            _spawnTimer = new Timer(AsteroidsModel.SpawnRate, true);
            _environment.TimersEngine.Add(_spawnTimer);
            
            _spawnTimer.OnTick += DefineNewAsteroid;
            _model.OnUpdate += Update;
            _model.OnAsteroidDestroyed += DestroyAsteroid;
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
            
            Debug.Log(nameof(AsteroidsPresenter) + " deactivated!");
        }

        private void Update(float deltaTime)
        {
            foreach (var model in _inActiveAsteroids)
            {
                DestroyAsteroid(model, true, false);
            }
            
            _inActiveAsteroids.Clear();

            foreach (var model in _model.GetActiveAsteroids().Keys)
            {
                var zoneLimits = _environment.GameSceneView.GameView.ZoneLimits;

                if (!(model.Position.x < zoneLimits.LeftSide) &&
                    !(model.Position.x > zoneLimits.RightSide) &&
                    !(model.Position.z > zoneLimits.TopSide) && 
                    !(model.Position.z < zoneLimits.BottomSide))
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

        private void DestroyAsteroid(AsteroidModel model, bool byBorder, bool byShip)
        {
            _asteroidsPresenters[model].Deactivate();
            _asteroidsPresenters.Remove(model);

            if (!byBorder && !byShip && model.Specification.SubAsteroidsOnDestroy.Count != 0)
            {
                foreach (var specification in model.Specification.SubAsteroidsOnDestroy.Select(item => item.Specification))
                {
                    var newPosition = new Vector3(model.Position.x + Random.Range(-7f, 7f), 0, model.Position.z + Random.Range(-7f, 7f));
                    
                    CreateAsteroid(specification, newPosition);
                }
            }

            _environment.PullsData.AsteroidsPulls[model.Specification.Type].PutBack(_model.GetByKey(model));
            _model.RemoveActiveAsteroid(model);
        }

        private void CreateAsteroid(AsteroidSpecification specification, Vector3 position)
        {
            var model = new AsteroidModel(specification, position);
            var view = _environment.PullsData.AsteroidsPulls[specification.Type].TryGetElement();
            var presenter = new AsteroidPresenter(_environment, model, view);
                        
            presenter.Activate();
            _asteroidsPresenters.Add(model, presenter);
            _model.AddActiveAsteroid(model, view);
        }

        private void DefineNewAsteroid()
        {
            var zoneLimits = _environment.GameSceneView.GameView.ZoneLimits;
            var position = new Vector3(Random.Range(zoneLimits.LeftSide + 2, zoneLimits.RightSide - 2), 0, zoneLimits.TopSide - 3f);
            var randomChance = Random.Range(0f, 1f);
            var randomType = AsteroidsTypes.Default;
            
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
            
            CreateAsteroid(_model.Specifications[randomType], position);
        }

        private void CreateAsteroidsPulls()
        {
            foreach (var pull in _environment.PullsData.AsteroidsPulls)
            {
                var pullView = _environment.GameSceneView.GameView.AsteroidsPullView.Find(item => item.Type == pull.Key);

                pullView.ElementPrefab = _model.Specifications[pull.Key].Prefab;
                
                pull.Value.CreatePull(pullView);
            }
        }
    }
}