using Game.Entities.Bullet;
using Global.Pulls.Base;
using UnityEngine;

namespace Global.Pulls.Bullets._3D
{
    public class BulletsPullView3D : MonoBehaviour, IPullView<BulletView3D>
    {
        [field: SerializeField] public Transform PullRoot { get; private set; }
        public BulletView3D ElementPrefab { get; set; }
        public int Count { get; set; }
        
        public BulletView3D CreateObject() => Instantiate(ElementPrefab, PullRoot);

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