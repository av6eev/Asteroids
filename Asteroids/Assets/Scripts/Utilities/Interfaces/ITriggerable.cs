using System;
using Global.Pulls.Base;

namespace Utilities.Interfaces
{
    public interface ITriggerable
    {
        event Action<string, IPullElementView> OnTriggered;
    }
}