using System;
using Global.Pulls.Base;
using UnityEngine;

namespace Utilities.Interfaces
{
    public interface ITriggerable
    {
        event Action<string, BasePullElementView> OnTriggered;
        void OnTriggerEnter(Collider other);
    }
}