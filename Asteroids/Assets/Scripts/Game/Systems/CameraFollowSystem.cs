using UnityEngine;
using Utilities;

namespace Game.Systems
{
    public class CameraFollowSystem : ISystem
    {
        private readonly Vector3 _offset = new(0f, 70f, 0f);

        public void Update(GameEnvironment environment)
        {
            environment.GameSceneView.MainCamera.transform.position = environment.GameSceneView.GameView.CurrentShip.transform.position + _offset;
        }
    }
}