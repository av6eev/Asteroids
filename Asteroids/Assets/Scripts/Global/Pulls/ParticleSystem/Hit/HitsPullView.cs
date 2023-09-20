using Global.Pulls.Base;
using UnityEngine;

namespace Global.Pulls.ParticleSystem.Hit
{
    public class HitsPullView : MonoBehaviour, IPullView<HitView>
    {
        [field: SerializeField] public Transform PullRoot { get; private set; }
        public HitView ElementPrefab { get; set; }
        public int Count { get; set; }
        
        public HitView CreateObject() => Instantiate(ElementPrefab, PullRoot);

        public void DestroyObjects()
        {
            for (var i = 0; i < PullRoot.childCount; i++)
            {
                Destroy(PullRoot.GetChild(i).gameObject);
            }
        }

        public void HideAll()
        {
            for (var i = 0; i < PullRoot.childCount; i++)
            {
                var child = PullRoot.GetChild(i).gameObject;
                
                if (!child.activeInHierarchy) continue;
                
                child.SetActive(false);
            }
        }
    }
}