using Global;
using UnityEngine;

namespace Game.CameraUpdater
{
    public sealed class ThirdPersonCameraFollowUpdater : BaseCameraFollowUpdater
    {
        public override Camera Camera { get; set; }
        public override Vector3 Offset { get; set; }
        
        private Vector3 _currentVelocity;
        private const float SMOOTH_TIME = 0.05f;

        public ThirdPersonCameraFollowUpdater(Vector3 offset, Camera camera)
        {
            Offset = offset;
            Camera = camera;
        }

        public override void Update(GlobalEnvironment environment)
        {
            var shipPosition = environment.ShipModel.MoveModel.Position;
            var target = GetTarget(shipPosition);
            var cameraPosition = Camera.transform.position;
            
            cameraPosition = Vector3.SmoothDamp(cameraPosition, new Vector3(cameraPosition.x, cameraPosition.y, target.z), ref _currentVelocity, SMOOTH_TIME);
            Camera.transform.position = cameraPosition;
            
            if (target.y < shipPosition.y)
            {
                target.y = shipPosition.y;
            }

            environment.GameModel.ZoneLimits.UpdateTopDownBorders(shipPosition.z + Mathf.Abs(Offset.z * 2), cameraPosition.z);
        }
    }
}