using UnityEngine;

namespace Global.Pulls.Base
{
    public abstract class BasePullView<T> : MonoBehaviour where T : BasePullElementView
    {
        [field: SerializeField] public Transform PullRoot { get; private set; }
        public T ElementPrefab { get; set; }
        public virtual int Count { get; set; }

        public T CreateObject() => Instantiate(ElementPrefab, PullRoot);

        public void DestroyObjects()
        {
            for (var i = 0; i < PullRoot.childCount; i++)
            {
                Destroy(PullRoot.GetChild(i).gameObject);
            }
        }
    }
}