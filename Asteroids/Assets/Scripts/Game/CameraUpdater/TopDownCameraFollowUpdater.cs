using Global;
using UnityEngine;

namespace Game.CameraUpdater
{
    public sealed class TopDownCameraFollowUpdater : BaseCameraFollowUpdater
    {
        public override Camera Camera { get; set; }
        public override Vector3 Offset { get; set; }

        private const float SMOOTH_TIME = 0.05f;
        private Vector3 _currentVelocity;

        public TopDownCameraFollowUpdater(Vector3 offset, Camera camera)
        {
            Offset = offset;
            Camera = camera;
        }

        public override void Update(GlobalEnvironment environment)
        {
            var target = GetTarget(environment.ShipModel.MoveModel.Position);
            var cameraPosition = Camera.transform.position;
            
            cameraPosition = Vector3.SmoothDamp(cameraPosition, new Vector3(cameraPosition.x, target.y, cameraPosition.z), ref _currentVelocity, SMOOTH_TIME);
            Camera.transform.position = cameraPosition;
            
            environment.GameModel.ZoneLimits.UpdateTopDownBorders(cameraPosition.y + 50, cameraPosition.y - 40);
        }
    }
}