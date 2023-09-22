using Game.Entities.Ship.Base;
using Game.Input.Base;
using Global.Pulls.Base;
using UnityEngine;
using Utilities.Enums;

namespace Game.Base
{
    public interface IGameView
    {
        IShipView CurrentShip { get; }
        IPullsViews PullsCollection { get; }
        
        IShipView InstantiateShip(IShipView prefab);
        IShipView RedrawShip(IShipView shipPrefab, Vector3 newPosition);
        void SwitchCamera(CameraDimensionsTypes type);
        BaseInputView CreateInputView<T>() where T : BaseInputView;
        void DestroyShip();
    }
}