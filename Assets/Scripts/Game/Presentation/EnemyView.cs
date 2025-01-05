using System;
using Game.Application.Gameplay;
using Game.Presentation.UI;
using UnityEngine;

namespace Game.Presentation
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        public event Action OnCollisionWithCar, OnCollisionWithBullet, OnCarDetected, OnOffRoad;
        
        [SerializeField] private GameObject explosionParticle;
        [SerializeField] private HealthBar healthBar;
        
        private Animator _animator;
        private GameObject _carObject;
        private bool _isFollowingCar;
        private float _speed;
        
        
        public void FollowCar(float speed)
        {
            _speed = speed;
            _isFollowingCar = true;
            _animator.SetTrigger("runToFollow");
        }

        public void Explode()
        {
            Destroy(Instantiate(explosionParticle, transform.position, Quaternion.identity), 2);
            Destroy(gameObject);
        }

        public void Disappear()
        {
            Destroy(gameObject);
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
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }
        
        private void FixedUpdate()
        {
            if (_isFollowingCar && _carObject.activeInHierarchy)
            {
                gameObject.transform.LookAt(
                    new Vector3(_carObject.transform.position.x, transform.position.y, _carObject.transform.position.z));
                
                transform.Translate(Vector3.forward * (_speed * Time.fixedDeltaTime));
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Car"))
            {
                _carObject = other.gameObject;
                OnCarDetected?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Road"))
            {
                OnOffRoad?.Invoke();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Car"))
            {
                OnCollisionWithCar?.Invoke();
            }
            
            else if (other.gameObject.CompareTag("Bullet"))
            {
                OnCollisionWithBullet?.Invoke();
            }
        }
        
    }
}