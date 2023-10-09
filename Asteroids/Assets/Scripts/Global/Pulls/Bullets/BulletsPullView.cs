using Game.Entities.Bullet.Base;
using UnityEngine;

namespace Global.Pulls.Bullets
{
    public class BulletsPullView : MonoBehaviour, IBulletsPullView
    {
        [field: SerializeField] public Transform PullRoot { get; private set; }
        [field: SerializeField] public int Count { get; private set; }
        public IBulletView ElementPrefab { get; set; }

        public IBulletView CreateObject() => (IBulletView)Instantiate((Object)ElementPrefab, PullRoot);

        public void DestroyObjects()
        {
            for (var i = 0; i < PullRoot.childCount; i++)
            {
                Destroy(PullRoot.GetChild(i).gameObject);
            }
        }
    }
}