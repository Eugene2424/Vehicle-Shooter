using System;
using UnityEngine;


namespace Game.Presentation
{
    public class Bullet : MonoBehaviour
    {
        private BulletObjectPool _pool;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void SetObjectPool(BulletObjectPool pool)
        {
            _pool = pool;
        }
        
        public void Shoot(Vector3 direction, float speed)
        {
            _rigidbody.velocity = direction.normalized * speed;
        }
        
        private void OnCollisionEnter(Collision other)
        {
            _pool.Return(this);
        }
    }
}