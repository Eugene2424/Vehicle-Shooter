namespace Game.Domain
{
    public class Enemy
    {
        public Health Health { get; private set; }
        public int Damage { get; private set; }
        public float Speed { get; private set; }
        
        public Enemy(Health health, int damage, float speed)
        {
            Health = health;
            Damage = damage;
            Speed = speed;
        }
    }
}