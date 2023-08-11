﻿using System.Collections.Generic;

namespace Utilities
{
    public class TimersEngine : ITimer
    {
        private readonly List<ITimer> _timers = new();

        public void Add(ITimer timer)
        {
            _timers.Add(timer);
        }

        public void Update(float deltaTime)
        {
            foreach (var timer in _timers)
            {
                timer.Update(deltaTime);
            }
        }

        public void Remove(ITimer timer)
        {
            _timers.Remove(timer);
        }

        public void Clear()
        {
            _timers.Clear();
        }
    }
}