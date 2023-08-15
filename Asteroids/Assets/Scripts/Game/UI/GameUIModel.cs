using Game.UI.Distance;
using Game.UI.Money;
using Game.UI.Score;

namespace Game.UI
{
    public class GameUIModel
    {
        public ScoreModel ScoreModel { get; set; } = new();
        public DistanceModel DistanceModel { get; set; } = new();
        public MoneyModel MoneyModel { get; set; } = new();
    }
}