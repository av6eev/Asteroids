using System.Collections.Generic;
using Game.Ship;
using Global.Pulls.Asteroids;
using Global.Pulls.Shots;
using Unity.Mathematics;
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
        [field: SerializeField] public List<AsteroidsPullView> AsteroidsPullView { get; private set; }
        public ShipView CurrentShip { get; private set; }
        
        public ShipView InstantiateShip(ShipView shipPrefab)
        {
            var go = Instantiate(shipPrefab, ShipSpawnPoint.position, quaternion.identity);
            
            go.transform.SetParent(ShipSpawnPoint);
            
            CurrentShip = go;
            
            return go;
        }
    }
}