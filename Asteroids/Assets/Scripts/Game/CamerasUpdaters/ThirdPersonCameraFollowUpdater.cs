using Game.CamerasUpdaters.Base;
using Global;
using Global.Base;
using UnityEngine;

namespace Game.CamerasUpdaters
{
    public sealed class ThirdPersonCameraFollowUpdater : BaseCameraFollowUpdater
    {
        public override Vector3 Offset { get; set; } = new(0f, 42f, -55f);
        
        private const float SMOOTH_TIME = 0.05f;
        private const string CameraName = "ThirdPersonCamera";
        private Vector3 _currentVelocity;

        public ThirdPersonCameraFollowUpdater() => Camera = GameObject.Find(CameraName).GetComponent<Camera>();
        
        public override void Update(IGlobalEnvironment environment)
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

        protected override Vector3 GetTarget(Vector3 shipPosition) => shipPosition + (Camera.transform.position - shipPosition).normalized + Offset;
    }
}