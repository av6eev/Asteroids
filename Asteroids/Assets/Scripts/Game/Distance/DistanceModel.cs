namespace Game.Distance
{
    public class DistanceModel
    {
        public float CurrentDistance { get; private set; } = 0;

        public void UpdateDistance(float bonus)
        {
            CurrentDistance += bonus;
        }
    }
}