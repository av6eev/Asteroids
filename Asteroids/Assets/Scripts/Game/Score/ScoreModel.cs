namespace Game.Score
{
    public class ScoreModel
    {
        public int CurrentScore { get; private set; } = 0;

        public void UpdateScore(int bonus)
        {
            CurrentScore += bonus;
        }
    }
}