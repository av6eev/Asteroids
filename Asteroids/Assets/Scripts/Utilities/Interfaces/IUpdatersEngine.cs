using Utilities.Enums;

namespace Utilities.Interfaces
{
    public interface IUpdatersEngine : IUpdater
    {
        void Add(UpdatersTypes type, IUpdater updater);
        void Remove(UpdatersTypes type);
        void Set(UpdatersTypes type, IUpdater updater);
        void Clear();
    }
}