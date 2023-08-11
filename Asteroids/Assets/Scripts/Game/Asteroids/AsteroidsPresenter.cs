using System;
using System.Collections.Generic;
using Game.Asteroids.Asteroid;
using UnityEngine;
using Utilities;
using Random = Unity.Mathematics.Random;

namespace Game.Asteroids
{
    public class AsteroidsPresenter : IPresenter
    {
        private readonly GameEnvironment _environment;
        private readonly AsteroidsModel _model;

        private readonly Dictionary<AsteroidModel, AsteroidPresenter> _asteroidsPresenters = new();
        private readonly List<AsteroidModel> _inActiveAsteroids = new();
        
        private Timer _spawnTimer;
        private Random _random;

        public AsteroidsPresenter(GameEnvironment environment, AsteroidsModel model)
        {
            _environment = environment;
            _model = model;
        }
        
        public void Activate()
        {
            CreateAsteroidsPulls();

            _random = new Random((uint)DateTime.Now.Millisecond);
            _spawnTimer = new Timer(_model.SpawnRate, true);
            _environment.TimersEngine.Add(_spawnTimer);
            
            _spawnTimer.OnTick += DefineNewAsteroid;
            _model.OnUpdate += Update;
            _model.OnAsteroidDestroyed += DestroyAsteroid;
        }

        public void Deactivate()
        {
            _spawnTimer.OnTick -= DefineNewAsteroid;
            _model.OnUpdate -= Update;
            _model.OnAsteroidDestroyed -= DestroyAsteroid;
        }

        private void Update(float deltaTime)
        {
            foreach (var model in _inActiveAsteroids)
            {
                DestroyAsteroid(model);
            }
            
            _inActiveAsteroids.Clear();

            var activeAsteroids = _model.GetActiveAsteroids();
            
            foreach (var model in activeAsteroids.Keys)
            {
                var zoneLimits = _environment.GameSceneView.GameView.ZoneLimits;

                if (!(model.Position.x < zoneLimits.LeftSide) && !(model.Position.x > zoneLimits.RightSide) && !(model.Position.z > zoneLimits.TopSide) && !(model.Position.z < zoneLimits.BottomSide)) continue;
                
                if (!_inActiveAsteroids.Contains(model))
                {
                    _inActiveAsteroids.Add(model);
                }
            }
            
            foreach (var model in activeAsteroids.Keys)
            {
                model.Update(deltaTime);
            }
        }

        private void DestroyAsteroid(AsteroidModel model)
        {
            _asteroidsPresenters[model].Deactivate();
            _asteroidsPresenters.Remove(model);

            _environment.PullsData.AsteroidsPulls[model.Specification.Type].PutBack(_model.GetActiveAsteroids()[model]);
            _model.GetActiveAsteroids().Remove(model);
        }

        private void CreateAsteroid(AsteroidsTypes type)
        {
            var zoneLimits = _environment.GameSceneView.GameView.ZoneLimits;
            
            var position = new Vector3(_random.NextFloat(zoneLimits.LeftSide + 2, zoneLimits.RightSide - 2), 0, zoneLimits.TopSide - 3f);
            var model = new AsteroidModel(_model.Specification[type], position);
            var view = _environment.PullsData.AsteroidsPulls[type].TryGetElement();
            var presenter = new AsteroidPresenter(_environment, model, view);
                        
            presenter.Activate();
            _asteroidsPresenters.Add(model, presenter);
            _model.AddActiveAsteroid(model, view);
        }

        private void DefineNewAsteroid()
        {
            var randomChance = _random.NextFloat();

            if (randomChance < _model.Specification[AsteroidsTypes.Fire].ChanceToSpawn)
            {
                CreateAsteroid(AsteroidsTypes.Fire);        
            }
            
            if (randomChance > _model.Specification[AsteroidsTypes.Fire].ChanceToSpawn && randomChance < _model.Specification[AsteroidsTypes.Big].ChanceToSpawn)
            {
                CreateAsteroid(AsteroidsTypes.Big);        
            }
            
            if (randomChance > _model.Specification[AsteroidsTypes.Big].ChanceToSpawn && randomChance < _model.Specification[AsteroidsTypes.Medium].ChanceToSpawn)
            {
                CreateAsteroid(AsteroidsTypes.Medium);        
            }
            
            if (randomChance > _model.Specification[AsteroidsTypes.Medium].ChanceToSpawn && randomChance < _model.Specification[AsteroidsTypes.Small].ChanceToSpawn || randomChance > _model.Specification[AsteroidsTypes.Small].ChanceToSpawn)
            {
                CreateAsteroid(AsteroidsTypes.Small);
            }
        }

        private void CreateAsteroidsPulls()
        {
            foreach (var pull in _environment.PullsData.AsteroidsPulls)
            {
                var pullView = _environment.GameSceneView.GameView.AsteroidsPullView.Find(item => item.Type == pull.Key);

                pullView.ElementPrefab = _model.Specification[pull.Key].Prefab;
                
                pull.Value.CreatePull(pullView);
            }
        }
    }
}