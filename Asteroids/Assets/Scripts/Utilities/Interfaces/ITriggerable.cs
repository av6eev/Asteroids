using System;
using Global.Pulls.Base.PullElement;

namespace Utilities.Interfaces
{
    public interface ITriggerable
    {
        event Action<string, IPullElementView> OnTriggered;
    }
}