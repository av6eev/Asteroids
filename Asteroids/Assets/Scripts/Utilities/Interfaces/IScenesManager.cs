using Global;
using Utilities.Enums;

namespace Utilities.Interfaces
{
    public interface IScenesManager
    {
        void LoadScene(ScenesNames sceneName, IGlobalEnvironment environment);
        void UnloadScene(ScenesNames sceneName);
    }
}