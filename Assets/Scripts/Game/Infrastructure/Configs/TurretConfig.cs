using UnityEngine;

namespace Game.Infrastructure.Configs
{
    [CreateAssetMenu(menuName = "Game/TurretConfig", fileName = "TurretConfig")] 
    public class TurretConfig : ScriptableObject
    {
        public float fireRate;
        public float bulletSpeed;
        public int bulletDamage;
        public float turretRotationSpeed;
    } 
}