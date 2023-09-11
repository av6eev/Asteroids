namespace Utilities.Interfaces
{
    public interface ITimersEngine : ITimer
    {
        void Add(ITimer timer);
        void Remove(ITimer timer);
        void Clear();
    }
}