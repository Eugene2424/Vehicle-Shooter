using System;

namespace Game.Application.Gameplay
{
    public interface IEnemyView
    {
        public event Action OnCollisionWithCar, OnCollisionWithBullet, OnCarDetected, OnOffRoad;
        
        public void FollowCar(float speed);

        public void Explode();
        public void Disappear();

        public void SetupHealthBar(int maxHealth);
        public void UpdateHealthBar(int health);
   
        public void ShowHealthBar();
        public void HideHealthBar();
    }
}