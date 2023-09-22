using Global.Pulls.ParticleSystem.Hit.Base;
using UnityEngine;

namespace Global.Pulls.ParticleSystem.Hit
{
    public class HitsPullView : MonoBehaviour, IHitsPullView
    {
        [field: SerializeField] public Transform PullRoot { get; private set; }
        [field: SerializeField] public int Count { get; private set; }
        public IHitView ElementPrefab { get; set; }

        public IHitView CreateObject() => (IHitView)Instantiate((Object)ElementPrefab, PullRoot);

        public void DestroyObjects()
        {
            for (var i = 0; i < PullRoot.childCount; i++)
            {
                Destroy(PullRoot.GetChild(i).gameObject);
            }
        }
    }
}