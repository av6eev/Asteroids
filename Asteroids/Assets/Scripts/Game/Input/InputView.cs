using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Input
{
    [RequireComponent(typeof(PlayerInput))]
    public class InputView : MonoBehaviour
    {
        [field: SerializeField] public PlayerInput PlayerInputAsset { get; private set; }
        [field: NonSerialized] public InputAction MoveAction { get; private set; }

        public void Awake()
        {
            MoveAction = PlayerInputAsset.actions.actionMaps[0].actions[0];
        }
    }
}