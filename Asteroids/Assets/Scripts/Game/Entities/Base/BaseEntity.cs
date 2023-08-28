namespace Game.Entities.Base
{
    public abstract class BaseEntity : IDamageable
    {
        public int Health { get; protected set; }
        
        public abstract void ApplyDamage(int damage);
    }
}