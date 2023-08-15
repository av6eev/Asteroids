namespace Game.UI.Money
{
    public class MoneyModel
    {
        public int MoneyGained { get; private set; }

        public void UpdateBalance(int bonus)
        {
            MoneyGained += bonus;
        }
    }
}