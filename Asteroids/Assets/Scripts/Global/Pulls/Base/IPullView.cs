using Global.Pulls.Base.PullElement;

namespace Global.Pulls.Base
{
    public interface IPullView<T> where T : IPullElementView
    {
        public T ElementPrefab { get; }
        public int Count { get;  }

        public T CreateObject();
        public void DestroyObjects();
        public void HideAll();
    }
}