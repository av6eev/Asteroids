using System.Collections.Generic;

namespace Utilities
{
    public class UpdatersEngine : IUpdater
    {
        private readonly Dictionary<UpdatersTypes, IUpdater> _updaters = new();

        public void Add(UpdatersTypes type, IUpdater updater)
        {
            _updaters.Add(type, updater);
        }

        public void Update(GameEnvironment environment)
        {
            foreach (var system in _updaters.Values)
            {
                system.Update(environment);
            }
        }

        public void Remove(UpdatersTypes type)
        {
            _updaters.Remove(type);
        }
        
        public void Clear()
        {
            _updaters.Clear();
        }
    }
}