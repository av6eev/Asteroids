using UnityEngine;

namespace Game.CameraUpdater
{
    public class ThirdPersonBaseCameraFollowUpdater : BaseCameraFollowUpdater
    {
        public ThirdPersonBaseCameraFollowUpdater(Vector3 offset, Camera camera) : base(offset, camera) {}
    }
}