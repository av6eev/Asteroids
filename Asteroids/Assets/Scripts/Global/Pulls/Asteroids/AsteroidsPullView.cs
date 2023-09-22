using Game.Entities.Asteroids;
using Game.Entities.Asteroids.Asteroid.Base;
using UnityEngine;

namespace Global.Pulls.Asteroids
{
    public class AsteroidsPullView : MonoBehaviour, IAsteroidsPullView
    {
        [field: SerializeField] public Transform PullRoot { get; private set; }
        [field: SerializeField] public AsteroidsTypes Type { get; private set; }
        [field: SerializeField] public int Count { get; private set; }
        public IAsteroidView ElementPrefab { get; set; }

        public IAsteroidView CreateObject() => (IAsteroidView)Instantiate((Object)ElementPrefab, PullRoot);

        public void DestroyObjects()
        {
            for (var i = 0; i < PullRoot.childCount; i++)
            {
                Destroy(PullRoot.GetChild(i).gameObject);
            }
        }
    }
}