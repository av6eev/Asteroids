using System.Collections.Generic;
using Game.Ship;
using Global.Pulls.Asteroids;
using Global.Pulls.ParticleSystem.Hit;
using Global.Pulls.Shots;
using UnityEngine;
using Utilities;

namespace Game
{
    public class GameView : MonoBehaviour
    {
        [field: SerializeField] public GameZoneLimits ZoneLimits { get; private set; }
        [field: SerializeField] public Transform ShipSpawnPoint { get; private set; }
        [field: Header("Pulls")]
        [field: SerializeField] public ShotsPullView ShotsPullView { get; private set; }
        [field: SerializeField] public HitsPullView HitsPullView { get; private set; }
        [field: SerializeField] public List<AsteroidsPullView> AsteroidsPullView { get; private set; }
        public ShipView CurrentShip { get; private set; }
        
        public ShipView InstantiateShip(ShipView shipPrefab)
        {
            var go = Instantiate(shipPrefab, ShipSpawnPoint.position, shipPrefab.transform.rotation);
            
            go.transform.SetParent(transform);
            
            CurrentShip = go;
            
            return go;
        }

        public void DestroyShip() => Destroy(CurrentShip.gameObject);

        public void DestroyPulls()
        {
            ShotsPullView.DestroyObjects();
            HitsPullView.DestroyObjects();
            
            foreach (var asteroidsPull in AsteroidsPullView)
            {
                asteroidsPull.DestroyObjects();                
            }
        }
    }
}