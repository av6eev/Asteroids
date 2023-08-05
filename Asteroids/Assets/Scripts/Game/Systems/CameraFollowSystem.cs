using UnityEngine;
using Utilities;

namespace Game.Systems
{
    public class CameraFollowSystem : ISystem
    {
        private readonly Vector3 _offset = new(0f, 45f, -35f);

        public void Update(GameEnvironment environment)
        {
            var shipPosition = environment.GameSceneView.GameView.CurrentShip.transform.position;
            
            environment.GameSceneView.MainCamera.transform.position = new Vector3(0, 0, shipPosition.z) + _offset;
        }
    }
}