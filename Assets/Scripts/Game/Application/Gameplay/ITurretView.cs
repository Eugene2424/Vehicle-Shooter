namespace Game.Application.Gameplay
{
    public interface ITurretView
    {
        public void Setup(float fireRate, float bulletSpeed, float turretRotationSpeed);
        
        public void EnableAutoShooting();
        public void DisableAutoShooting();
    }
}