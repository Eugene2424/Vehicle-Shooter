using UnityEngine;

namespace Game.Infrastructure.Configs
{
    [CreateAssetMenu(menuName = "Game/EnemiesConfig", fileName = "EnemiesConfig")] 
    public class EnemiesConfig : ScriptableObject
    {
        public int health;
        public float speed;
        public int damage;
    }
}