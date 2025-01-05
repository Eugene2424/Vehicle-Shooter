using System;

namespace Game.Domain
{
    public class Health
    {
        public event Action OnDeath;
        public event Action OnHealthChanged;
        
        public int Current { get; private set; }
        public int Max { get; private set; }

        public Health(int current, int max)
        {
            Current = current;
            Max = max;
        }

        public void TakeDamage(int amount)
        {
            Current = Current - amount < 0 ? 0 : Current - amount;
            OnHealthChanged?.Invoke();
            if (Current == 0) OnDeath?.Invoke();
        }

        public void Heal(int amount)
        {
            Current = Current + amount > Max ? Max : Current + amount;
            OnHealthChanged?.Invoke();
        }
    }
}