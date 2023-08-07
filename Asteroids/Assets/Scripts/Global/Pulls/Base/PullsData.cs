using Global.Pulls.Shots;

namespace Global.Pulls.Base
{
    public class PullsData
    {
        public ShotsPull ShotsPull { get; private set; } = new();
    }
}