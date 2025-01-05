using Game.Application;
using Game.Presentation.UI;
using UnityEngine;
using System;
using Game.Application.Gameplay;

namespace Game.Presentation
{
    public class CarView :  MonoBehaviour, ICarView, IDistanceProgressProvider
    {
        public event Action OnCollsionWithEnemy, OnDistanceFinished;
        public event Action<float> OnDistanceProgressChanged;
        
        [SerializeField] private HealthBar healthBar;

        private float _speed;
        private bool _isGoingForward;
        private float _startPosZ;

        private float _distanceToStop;

        private void Start()
        {
            _startPosZ = transform.position.z;
        }

        private void FixedUpdate()
        {
            if (_isGoingForward)
            {
                if (_startPosZ + _distanceToStop <= transform.position.z)
                {
                    OnDistanceFinished?.Invoke();
                }
                transform.Translate(Vector3.forward * (Time.fixedDeltaTime * _speed));
                OnDistanceProgressChanged?.Invoke(_distanceToStop - (transform.position.z - _startPosZ));
            }
                
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.CompareTag("Enemy"))
            {
                OnCollsionWithEnemy?.Invoke();
            }
        }

        public void SetupHealthBar(int maxHealth)
        {
            healthBar.SetMaxHealth(maxHealth);
        }
        
        public void UpdateHealthBar(int health)
        {
            healthBar.SetHealth(health);
        }
        
        public void ShowHealthBar() => healthBar.Show();
        public void HideHealthBar() => healthBar.Hide();
        
        public void ShowDeath()
        {
            gameObject.SetActive(false);
        }
        
        public void GoForward(float speed, float distance)
        {
            _isGoingForward = true;
            _speed = speed;
            _distanceToStop = distance;
        }

        public void StopMoving()
        {
            _isGoingForward = false;
        }

        public float GetDistanceProgress()
        {
            return transform.position.z / (_startPosZ + _distanceToStop);
        }

        public float GetDistance()
        {
            return _distanceToStop;
        }
    }
}