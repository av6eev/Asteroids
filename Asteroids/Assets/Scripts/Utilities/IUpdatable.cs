using System;

namespace Utilities
{
    public interface IUpdatable
    {
        event Action<float> OnUpdate;
        void Update(float deltaTime);
    }
}