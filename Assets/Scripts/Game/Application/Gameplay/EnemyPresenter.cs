using Game.Application.Abstractions;
using Game.Domain;

namespace Game.Application.Gameplay
{
    public class EnemyPresenter : IPresenter
    {
        private readonly Enemy _enemy;
        private readonly IEnemyView _view;
        private readonly IGameplaySettings _settings;

        public EnemyPresenter(IEnemyView view, IGameplaySettings settings)
        {
            _enemy = new Enemy(new Health(settings.EnemySettings.InitialHealth, 
                settings.EnemySettings.MaxHealth), settings.EnemySettings.Damage, settings.EnemySettings.Speed);
            _view = view;
            _settings = settings;
        }

        public void Initialize()
        {
            _view.SetupHealthBar(_enemy.Health.Max);
            _view.OnCarDetected += HandleCarDetected;
            _view.OnOffRoad += HandleOffRoad;
            _view.OnCollisionWithCar += HandleCollisionWithCar;
            _view.OnCollisionWithBullet += HandleCollisionWithBullet;

            _enemy.Health.OnDeath += HandleDeath;
            _enemy.Health.OnHealthChanged += HandleHealthChanged;
        }

        public void Dispose()
        {
            _view.OnCarDetected -= HandleCarDetected;
            _view.OnOffRoad -= HandleOffRoad;
            _view.OnCollisionWithCar -= HandleCollisionWithCar;
            _view.OnCollisionWithBullet -= HandleCollisionWithBullet;

            _enemy.Health.OnDeath -= HandleDeath;
            _enemy.Health.OnHealthChanged -= HandleHealthChanged;
        }

        private void HandleCarDetected()
        {
            _view.FollowCar(_enemy.Speed);
        }

        private void HandleOffRoad()
        {
            Dispose();
            _view.Disappear();
        }

        private void HandleCollisionWithCar()
        {
            Dispose();
            _view.Explode();
        }

        private void HandleCollisionWithBullet()
        {
            _view.ShowHealthBar();
            _enemy.Health.TakeDamage(_settings.TurretSettings.BulletDamage);
        }

        private void HandleDeath()
        {
            Dispose();
            _view.Explode();
        }

        private void HandleHealthChanged()
        {
            _view.UpdateHealthBar(_enemy.Health.Current);
        }
        
    }
}