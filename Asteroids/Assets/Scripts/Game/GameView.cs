using Game.Ship;
using Global.Pulls.Shots;
using Unity.Mathematics;
using UnityEngine;

namespace Game
{
    public class GameView : MonoBehaviour
    {
        [field: SerializeField] public ShotsPullView ShotsPullView { get; private set; }
        public ShipView CurrentShip { get; private set; }
        
        public ShipView InstantiateShip(ShipView shipPrefab, Vector3 spawnPoint)
        {
            var go = Instantiate(shipPrefab,  spawnPoint, quaternion.identity);
            
            go.transform.SetParent(transform);
            
            CurrentShip = go;
            
            return go;
        }
    }
}