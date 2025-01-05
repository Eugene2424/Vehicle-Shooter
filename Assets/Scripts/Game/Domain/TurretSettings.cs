namespace Game.Domain
{
    public class TurretSettings
    {
        public float FireRate { get; private set; }
        public float BulletSpeed { get; private set; }
        public int BulletDamage { get; private set; }
        public float RotationSpeed { get; private set; }
        
        public TurretSettings(float fireRate, float bulletSpeed, int bulletDamage, float turretRotationSpeed)
        {
            FireRate = fireRate;
            BulletSpeed = bulletSpeed;
            BulletDamage = bulletDamage;
            RotationSpeed = turretRotationSpeed;
        }
    }
}