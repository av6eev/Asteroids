using Global;
using UnityEngine;
using Utilities;

namespace Game.CameraUpdater
{
    public abstract class BaseCameraFollowUpdater : IUpdater
    {
        public abstract Camera Camera { get; set; }
        public abstract Vector3 Offset { get; set; }

        public abstract void Update(GlobalEnvironment environment);

        protected virtual Vector3 GetTarget(Vector3 shipPosition) => shipPosition + (Camera.transform.position - shipPosition).normalized + Offset;
    }
}