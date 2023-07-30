using System.Collections.Generic;

namespace Utilities
{
    public class SystemsEngine
    {
        private readonly Dictionary<SystemsTypes, ISystem> _systems = new();

        public void Add(SystemsTypes type, ISystem system)
        {
            _systems.Add(type, system);
        }

        public void Update(GameEnvironment environment)
        {
            foreach (var system in _systems.Values)
            {
                system.Update(environment);
            }
        }

        public void Remove(SystemsTypes type)
        {
            _systems.Remove(type);
        }
        
        public void Clear()
        {
            _systems.Clear();
        }
    }
}