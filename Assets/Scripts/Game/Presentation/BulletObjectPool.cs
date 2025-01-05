using UnityEngine;
using System.Collections.Generic;

namespace Game.Presentation
{
    public class BulletObjectPool : MonoBehaviour
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private int poolSize = 10; 

        private Queue<Bullet> _pool;

        private void Awake()
        {
            _pool = new Queue<Bullet>();
    
            for (int i = 0; i < poolSize; i++)
            {
                Bullet bullet = Instantiate(bulletPrefab);
                bullet.SetObjectPool(this);
                bullet.gameObject.SetActive(false); 
                _pool.Enqueue(bullet);   
            }
        }

        public Bullet Get()
        {
            if (_pool.Count > 0)
            {
                Bullet bullet = _pool.Dequeue();
                bullet.gameObject.SetActive(true); 
                return bullet;
            }

            Bullet newBullet = Instantiate(bulletPrefab);
            newBullet.SetObjectPool(this);
            newBullet.gameObject.SetActive(true);
            return newBullet;
        }

        public void Return(Bullet bullet)
        {
            bullet.gameObject.SetActive(false); 
            _pool.Enqueue(bullet);   
        }
    }
}