using System;
using Game.Application.Abstractions;
using Game.Application.Commands;
using Game.Application.Events;
using Game.Application.GameStates;
using Game.Domain;

namespace Game.Application.Gameplay
{
    public class CarPresenter : IPresenter
    {
        private readonly Car _car;
        private readonly ICarView _carView;
        private readonly EventBus _eventBus;
        private readonly ICommandMediator _mediator;
        private readonly IGameplaySettings _settings;

        public CarPresenter(ICarView carView, IGameplaySettings settings, EventBus eventBus, ICommandMediator mediator)
        {
            _car = new Car(settings.CarSettings);
            _settings = settings;
            _carView = carView;
            _eventBus = eventBus;
            _mediator = mediator;
        }

        public void Initialize()
        {
            _eventBus.Subscribe<GameStateEnterEvent>(HandleGameStateEnter);
            _car.Health.OnHealthChanged += HandleHealthChanged;
            _car.Health.OnDeath += HandleDeath;
            _carView.OnDistanceFinished += HandleDistanceFinished;
            _carView.OnCollsionWithEnemy += HandleCollisionWithEnemy;
        }
        
        public void Dispose()
        {
            _eventBus.Unsubscribe<GameStateEnterEvent>(HandleGameStateEnter);
            _car.Health.OnHealthChanged -= HandleHealthChanged;
            _car.Health.OnDeath -= HandleDeath;
            _carView.OnDistanceFinished -= HandleDistanceFinished;
            _carView.OnCollsionWithEnemy -= HandleCollisionWithEnemy;
        }

        private void HandleGameStateEnter(GameStateEnterEvent evt)
        {
            if (evt.State == GameState.Gameplay)
            {
                _carView.SetupHealthBar(_car.Health.Max);
                _carView.ShowHealthBar();
                _carView.GoForward(_car.Speed.Current, _car.DistanceToFinish);
            }
        }
        
        private void HandleHealthChanged()
        {
            _carView.UpdateHealthBar(_car.Health.Current);
        }

        private void HandleDeath()
        {
            _carView.ShowDeath();
            _mediator.Execute<LoseCommand>();
        }

        public void HandleDistanceFinished()
        {
            _carView.StopMoving();
            _mediator.Execute<WinCommand>();
        }

        private void HandleCollisionWithEnemy()
        {
            _car.Health.TakeDamage(_settings.EnemySettings.Damage);
        }
    }
}