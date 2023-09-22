using System;
using Game.Base;
using Game.Entities.Ship.Base;
using Game.Input.Base;
using Global.Pulls;
using Global.Pulls.Base;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilities.Enums;

namespace Game
{
    public class GameView : MonoBehaviour, IGameView
    {
        [field: SerializeField] public Transform ShipSpawnPoint { get; private set; }
        [field: SerializeField] public Camera TopDownCamera { get; private set; }
        [field: SerializeField] public Camera ThirdPersonCamera { get; private set; }
        [field: SerializeField] public InputActionAsset PlayerInputAsset { get; private set; }
        [field: NonSerialized] private BaseInputView InputView { get; set; }
        [field: NonSerialized] public IShipView CurrentShip { get; private set; }

        [field: Header("Pulls")]
        [field: SerializeField] public PullsViews PullsCollectionGo { get; private set; }

        public IPullsViews PullsCollection => PullsCollectionGo;
        
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
        
        public void SwitchCamera(CameraDimensionsTypes type)
        {
            switch (type)
            {
                case CameraDimensionsTypes.TwoD:
                    TopDownCamera.gameObject.SetActive(true);
                    ThirdPersonCamera.gameObject.SetActive(false);
                    break;
                case CameraDimensionsTypes.ThreeD:
                    TopDownCamera.gameObject.SetActive(false);
                    ThirdPersonCamera.gameObject.SetActive(true);
                    break;
            }
        }

        public BaseInputView CreateInputView<T>() where T : BaseInputView
        {
            var newInputView = new GameObject("InputView").AddComponent<T>();
            var playerInput = newInputView.AddComponent<PlayerInput>();

            playerInput.actions = PlayerInputAsset;
            playerInput.defaultActionMap = PlayerInputAsset.actionMaps[0].name;
            
            newInputView.PlayerInput = playerInput;
            newInputView.transform.SetParent(GameObject.Find("Views").transform);
            
            InputView = newInputView;
            
            return InputView;
        }

        public void DestroyShip() => Destroy(((MonoBehaviour)CurrentShip).gameObject);
    }
}