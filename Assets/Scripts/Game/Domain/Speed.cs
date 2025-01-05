using System;

namespace Game.Domain
{
    public class Speed
    {
        public event Action OnStop;
        public event Action OnSpeedChanged;
        
        public float Current { get; private set; }

        public Speed(float current)
        {
            Current = current;
        }

        public void Accelerate(float amount)
        {
            Current += amount;
            OnSpeedChanged?.Invoke();
        }

        public void Stop()
        {
            Current = 0;
            OnStop?.Invoke();
        }
    }
}