using Game.Entities.Asteroids;
using Game.Entities.Asteroids.Asteroid;
using Global.Pulls.Base;
using UnityEngine;

namespace Global.Pulls.Asteroids._2D
{
    public class AsteroidsPullView2D : MonoBehaviour, IPullView<AsteroidView2D>
    {
        [field: SerializeField] public Transform PullRoot { get; private set; }
        [field: SerializeField] public AsteroidsTypes Type { get; private set; }
        public AsteroidView2D ElementPrefab { get; set; }
        public int Count { get; set; }
        
        public AsteroidView2D CreateObject() => Instantiate(ElementPrefab, PullRoot);

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