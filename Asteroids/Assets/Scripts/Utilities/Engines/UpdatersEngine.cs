using System.Collections.Generic;
using Global;
using Utilities.Enums;
using Utilities.Interfaces;

namespace Utilities.Engines
{
    public class UpdatersEngine : IUpdatersEngine
    {
        private readonly Dictionary<UpdatersTypes, IUpdater> _updaters = new();

        public void Update(GlobalEnvironment environment)
        {
            foreach (var system in _updaters.Values)
            {
                system.Update(environment);
            }
        }

        public void Add(UpdatersTypes type, IUpdater updater) => _updaters.Add(type, updater);

        public void Remove(UpdatersTypes type) => _updaters.Remove(type);
        
        public void Set(UpdatersTypes type, IUpdater updater)
        {
            if (_updaters.ContainsKey(type))
            {
                _updaters[type] = updater;
            }
        }

        public void Clear() => _updaters.Clear();
    }
}