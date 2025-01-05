using UnityEngine;

namespace Game.Infrastructure.Configs
{
    [CreateAssetMenu(menuName = "Game/CarConfig", fileName = "CarConfig")] 
    public class CarConfig : ScriptableObject 
    { 
        public int initialHealth;
        public int maxHealth;
        public int damage;
        public int initialSpeed;
        public float distanceToFinish;
    } 
}

