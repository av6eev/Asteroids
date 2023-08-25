using UnityEngine;

namespace Game.CameraUpdater
{
    public class TopDownBaseCameraFollowUpdater : BaseCameraFollowUpdater
    {
        public TopDownBaseCameraFollowUpdater(Vector3 offset, Camera camera) : base(offset, camera) { }
    }
}