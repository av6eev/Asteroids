using Game.CamerasUpdaters.Base;
using Global;
using UnityEngine;

namespace Game.CamerasUpdaters
{
    public sealed class TopDownCameraFollowUpdater : BaseCameraFollowUpdater
    {
        public override Vector3 Offset { get; set; } = new(0f, 30f, -1f);
        
        private const float SMOOTH_TIME = 0.05f;
        private const string CameraName = "TopDownCamera";
        private Vector3 _currentVelocity;

        public TopDownCameraFollowUpdater() => Camera = GameObject.Find(CameraName).GetComponent<Camera>();

        public override void Update(IGlobalEnvironment environment)
        {
            var target = GetTarget(environment.ShipModel.MoveModel.Position);
            var cameraPosition = Camera.transform.position;
            
            cameraPosition = Vector3.SmoothDamp(cameraPosition, new Vector3(cameraPosition.x, target.y, cameraPosition.z), ref _currentVelocity, SMOOTH_TIME);
            Camera.transform.position = cameraPosition;
            
            environment.GameModel.ZoneLimits.UpdateTopDownBorders(cameraPosition.y + 50, cameraPosition.y - 40);
        }

        protected override Vector3 GetTarget(Vector3 shipPosition) => shipPosition + (Camera.transform.position - shipPosition).normalized + Offset;
    }
}