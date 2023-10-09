namespace Global.Pulls.Base
{
    public interface IPullView<T> where T : IPullElementView
    {
        public T ElementPrefab { get; set; }
        public int Count { get; }

        public T CreateObject();
        public void DestroyObjects();
    }
}