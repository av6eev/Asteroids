using Global.Pulls.Base;
using UnityEngine;

namespace Global.Pulls.ParticleSystem.Hit.Base
{
    public interface IHitView : IPullElementView
    {
        void SetPosition(Vector3 newPosition);
    }
}