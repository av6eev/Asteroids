using Global;
using UnityEngine;
using Utilities;

namespace Game.CameraUpdater
{
    public abstract class BaseCameraFollowUpdater : IUpdater
    {
        private Camera Camera { get; }
        private Vector3 Offset { get; }
        
        private Vector3 _currentVelocity;
        private const float SMOOTH_TIME = 0.05f;
        
        protected BaseCameraFollowUpdater(Vector3 offset, Camera camera)
        {
            Offset = offset;
            Camera = camera;
        }

        public void Update(GlobalEnvironment environment)
        {
            var shipPosition = environment.GameSceneView.GameView.CurrentShip.transform.position;
            var cameraTransform = Camera.transform;
            var cameraPosition = cameraTransform.position;
            var target = shipPosition + (cameraPosition - shipPosition).normalized + Offset;
            
            cameraPosition = Vector3.SmoothDamp(cameraPosition, new Vector3(cameraPosition.x, cameraPosition.y, target.z), ref _currentVelocity, SMOOTH_TIME);
            cameraTransform.position = cameraPosition;
            
            if (target.y < shipPosition.y)
            {
                target.y = shipPosition.y;
            }
        }
    }
}