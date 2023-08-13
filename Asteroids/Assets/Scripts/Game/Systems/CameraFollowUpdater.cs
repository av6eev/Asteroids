using Global;
using UnityEngine;
using Utilities;

namespace Game.Systems
{
    public class CameraFollowUpdater : IUpdater
    {
        private readonly Vector3 _offset = new(0f, 70f, 30f);

        private const float SMOOTH_TIME = 0.05f;
        private Vector3 _currentVelocity;

        public void Update(GlobalEnvironment environment)
        {
            var shipTransform = environment.GameSceneView.GameView.CurrentShip.transform;
            var shipPosition = shipTransform.position;
            var cameraTransform = environment.GameSceneView.MainCamera.transform;
            var cameraPosition = cameraTransform.position;
            var target = shipPosition + (cameraPosition - shipPosition).normalized + _offset;
            
            cameraPosition = Vector3.SmoothDamp(cameraPosition, new Vector3(cameraPosition.x, cameraPosition.y, target.z), ref _currentVelocity, SMOOTH_TIME);
            cameraTransform.position = cameraPosition;
            
            if (target.y < shipPosition.y)
            {
                target.y = shipPosition.y;
            }
        }
    }
}