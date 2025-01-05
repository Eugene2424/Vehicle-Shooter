namespace Game.Domain
{
    public class EnemySettings
    {
        public int InitialHealth { get; private set; }
        public int MaxHealth { get; private set; }
        public float Speed { get; private set; }
        public int Damage { get; private set; }
        
        
        public EnemySettings(int initialHealth, int maxHealth, int damage, float speed)
        {
            InitialHealth = initialHealth;
            MaxHealth = maxHealth;
            Damage = damage;
            Speed = speed;
        }
    }
}