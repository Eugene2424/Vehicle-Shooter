namespace Game.Domain
{
    public class Car
    {
        public Health Health { get; private set; }
        public Speed Speed { get; private set; }
        public float DistanceToFinish { get; private set; }
        
        public Car(CarSettings settings)
        {
            Health = new Health(settings.InitialHealth, settings.MaxHealth);
            Speed = new Speed(settings.Speed);
            DistanceToFinish = settings.DistanceToFinish;
        }
    }
}