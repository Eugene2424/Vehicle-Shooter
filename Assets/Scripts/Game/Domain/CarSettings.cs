namespace Game.Domain
{
    public class CarSettings
    {
        public int InitialHealth { get; private set; }
        public int MaxHealth { get; private set; }
        public int Speed { get; private set; }
        public int Damage { get; private set; }
        public float DistanceToFinish { get; private set; }
        
        public CarSettings(int initialHealth, int maxHealth, int damage, int speed, float distanceToFinish)
        {
            InitialHealth = initialHealth;
            MaxHealth = maxHealth;
            Damage = damage;
            Speed = speed;
            DistanceToFinish = distanceToFinish;
        }
    }
}