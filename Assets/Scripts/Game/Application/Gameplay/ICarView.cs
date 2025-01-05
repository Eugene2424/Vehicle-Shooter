using System;

namespace Game.Application.Gameplay
{
    public interface ICarView
    {

        public event Action OnCollsionWithEnemy, OnDistanceFinished;
        public void SetupHealthBar(int maxHealth);
        public void UpdateHealthBar(int health);
        public void ShowHealthBar();
        public void HideHealthBar();
        
        public void ShowDeath();
        
        public void GoForward(float speed, float distance);
        public void StopMoving();
    }
}