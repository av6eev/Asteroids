using Global;
using Utilities.Enums;

namespace Utilities.Interfaces
{
    public interface IScenesManager
    {
        void LoadScene(ScenesNames sceneName, GlobalEnvironment environment);
        void UnloadScene(ScenesNames sceneName);
    }
}