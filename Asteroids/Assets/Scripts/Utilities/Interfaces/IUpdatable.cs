using System;

namespace Utilities.Interfaces
{
    public interface IUpdatable
    {
        event Action<float> OnUpdate;
        void Update(float deltaTime);
    }
}