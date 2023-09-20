using System;
using System.Collections.Generic;
using Game.Entities.Ship.Base;
using Global.Pulls.Asteroids._2D;
using Global.Pulls.Asteroids._3D;
using Global.Pulls.Bullets._2D;
using Global.Pulls.Bullets._3D;
using Global.Pulls.ParticleSystem.Hit;
using UnityEngine;
using Utilities.Enums;

namespace Game
{
    public class GameView : MonoBehaviour
    {
        [field: SerializeField] public Transform ShipSpawnPoint { get; private set; }
        [field: Header("Pulls")]
        [field: SerializeField] public BulletsPullView3D BulletsPullView3D { get; private set; }
        [field: SerializeField] public BulletsPullView2D BulletsPullView2D { get; private set; }
        [field: SerializeField] public HitsPullView HitsPullView { get; private set; }
        [field: SerializeField] public List<AsteroidsPullView3D> AsteroidsPullView3D { get; private set; }
        [field: SerializeField] public List<AsteroidsPullView2D> AsteroidsPullView2D { get; private set; }
        [field: NonSerialized] public IShipView CurrentShip { get; private set; }
        
        public IShipView InstantiateShip(IShipView shipPrefab)
        {
            var go = (IShipView)Instantiate((UnityEngine.Object)shipPrefab, ShipSpawnPoint);
            CurrentShip = go;
            
            return go;
        }

        public IShipView RedrawShip(IShipView shipPrefab, Vector3 newPosition)
        {
            DestroyShip();

            var go = (IShipView)Instantiate((UnityEngine.Object)shipPrefab, newPosition, Quaternion.identity, ShipSpawnPoint);
            CurrentShip = go;
            
            return go;
        }

        public void DestroyPulls()
        {
            BulletsPullView3D.DestroyObjects();
            BulletsPullView2D.DestroyObjects();
            HitsPullView.DestroyObjects();
            
            foreach (var pull in AsteroidsPullView3D)
            {
                pull.DestroyObjects();                
            }
            
            foreach (var pull in AsteroidsPullView2D)
            {
                pull.DestroyObjects();                
            }
        }

        public void ChangeActivePulls(CameraDimensionsTypes dimension)
        {
            switch (dimension)
            {
                case CameraDimensionsTypes.TwoD:
                    foreach (var pull in AsteroidsPullView3D)
                    {
                        pull.HideAll();
                    }
                    
                    BulletsPullView3D.HideAll();
                    break;
                case CameraDimensionsTypes.ThreeD:
                    foreach (var pull in AsteroidsPullView2D)
                    {
                        pull.HideAll();
                    }
                    
                    BulletsPullView2D.HideAll();
                    break;
            }
        }

        public void DestroyShip() => Destroy(((MonoBehaviour)CurrentShip).gameObject);
    }
}