using Game.Application.Gameplay;
using UnityEngine;
using Zenject;

namespace Game.Infrastructure
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly DiContainer _container;
        private readonly GameObject _prefab;

        public EnemyFactory(DiContainer container, GameObject prefab)
        {
            _container = container;
            _prefab = prefab;
        }

        public void CreateEnemy(float x, float y, float z)
        {
            var enemy = _container.InstantiatePrefab(_prefab, new Vector3(x, y, z), _prefab.transform.rotation, null);
            var view = enemy.GetComponent<IEnemyView>();
            var settings = _container.Resolve<IGameplaySettings>();
            var presenter = _container.Instantiate<EnemyPresenter>(new object[] { view, settings });
            presenter.Initialize();
        }
    }
}