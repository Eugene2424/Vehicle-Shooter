using Game.Application.Abstractions;
using Game.Application.Events;
using Game.Application.GameStates;
using Game.Domain;

namespace Game.Application.Gameplay
{
    public class TurretPresenter : IPresenter
    {
        private readonly TurretSettings _settings;
        private readonly ITurretView _turretView;
        private readonly EventBus _eventBus;

        public TurretPresenter(ITurretView turretView, IGameplaySettings settings, EventBus eventBus)
        {
            _turretView = turretView;
            _settings = settings.TurretSettings;
            _eventBus = eventBus;
        }

        public void Initialize()
        {
            _eventBus.Subscribe<GameStateEnterEvent>(HandleGameStateEnter);
            _eventBus.Subscribe<GameStateExitEvent>(HandleGameStateExit);
            _turretView.Setup(_settings.FireRate, _settings.BulletSpeed, _settings.RotationSpeed);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<GameStateEnterEvent>(HandleGameStateEnter);
            _eventBus.Unsubscribe<GameStateExitEvent>(HandleGameStateExit);
        }

        private void HandleGameStateEnter(GameStateEnterEvent evt)
        {
            if (evt.State == GameState.Gameplay)
            {
                _turretView.EnableAutoShooting();
            }
        }
        
        private void HandleGameStateExit(GameStateExitEvent evt)
        {
            if (evt.State == GameState.Gameplay)
            {
                _turretView.DisableAutoShooting();
            }
        }
    }
}