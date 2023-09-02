using System.Collections.Generic;
using Utilities.Interfaces;

namespace Utilities.Engines
{
    public class TimersEngine : ITimer
    {
        private readonly List<ITimer> _timers = new();

        public void Update(float deltaTime)
        {
            foreach (var timer in _timers)
            {
                timer.Update(deltaTime);
            }
        }

        public void Add(ITimer timer) => _timers.Add(timer);

        public void Remove(ITimer timer) => _timers.Remove(timer);

        public void Clear() => _timers.Clear();
    }
}