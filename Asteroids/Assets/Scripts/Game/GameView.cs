using Game.Ship;
using Unity.Mathematics;
using UnityEngine;

namespace Game
{
    public class GameView : MonoBehaviour
    {
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