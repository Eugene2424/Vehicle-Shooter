using System;
using System.Collections;
using UnityEngine;
using Game.Controls;
using Game.Application.Gameplay;

namespace Game.Presentation
{
    public class TurretView : MonoBehaviour, ITurretView
    {
        [SerializeField] private BulletObjectPool bulletPool;
        [SerializeField] private Transform bulletSpawn;
        
        private float _bulletSpeed;
        private float _rotationSpeed;
        
        private float _fireRate = 0.5f;
        private bool _isAimEnabled, _isRotating, _isAutoShootingEnabled;

        private TurretControls _controls;
        private Vector2 _swipeDelta;

        private void Awake()
        {
            _controls = new TurretControls();

            _controls.Turret.Look.performed += ctx => _swipeDelta = ctx.ReadValue<Vector2>();
            _controls.Turret.Look.canceled += ctx => _swipeDelta = Vector2.zero;

            _controls.Turret.TouchPress.performed += ctx => _isRotating = true;
            _controls.Turret.TouchPress.canceled += ctx => _isRotating = false;
            
        }

        private void Update()
        {
            // Rotate the turret based on swipe delta
            if (_swipeDelta != Vector2.zero && _isRotating && _isAimEnabled)
            {
                float rotationAmount = _swipeDelta.x * _rotationSpeed * Time.deltaTime;
                transform.Rotate(0, 0, rotationAmount);
            }
        }

        public void Setup(float fireRate, float bulletSpeed, float turretRotationSpeed)
        {
            _fireRate = fireRate;
            _bulletSpeed = bulletSpeed;
            _rotationSpeed = turretRotationSpeed;
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        public void EnableAutoShooting()
        {
            _isAimEnabled = true;
            _isAutoShootingEnabled = true;
            StartCoroutine(AutoShootingRoutine());
        }
        
        public void DisableAutoShooting()
        {
            _isAimEnabled = false;
            _isAutoShootingEnabled = false;
        }

        private IEnumerator AutoShootingRoutine()
        {
            while (_isAutoShootingEnabled)
            {
                Shoot();
                yield return new WaitForSeconds(_fireRate);
            }
        }

        private void Shoot()
        {
            Bullet bullet = bulletPool.Get();
            
            bullet.transform.position = bulletSpawn.position;
            bullet.transform.rotation = bulletSpawn.rotation;
            
            bullet.Shoot(bulletSpawn.up, _bulletSpeed);
            
        }
    }
}