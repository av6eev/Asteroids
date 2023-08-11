using System;
using Global.Pulls.Base;
using UnityEngine;

namespace Utilities
{
    public interface IColliable
    {
        event Action<string, BasePullElementView> OnCollision;
        void OnCollisionEnter(Collision otherGo);
    }
}