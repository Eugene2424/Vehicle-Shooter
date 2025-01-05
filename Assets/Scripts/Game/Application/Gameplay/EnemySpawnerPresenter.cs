using Game.Application.Abstractions;
using Game.Application.Events;
using Game.Application.GameStates;

namespace Game.Application.Gameplay
{
    public class EnemySpawnerPresenter : IPresenter
    {
        private readonly IEnemySpawner _spawner;
        private readonly EventBus _eventBus;

        public EnemySpawnerPresenter(IEnemySpawner spawner, EventBus eventBus)
        {
            _spawner = spawner;
            _eventBus = eventBus;
        }

        public void Initialize()
        {
            _eventBus.Subscribe<GameStateEnterEvent>(HandleGameStateEnter);
            _eventBus.Subscribe<GameStateExitEvent>(HandleGameStateExit);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<GameStateEnterEvent>(HandleGameStateEnter);
            _eventBus.Unsubscribe<GameStateExitEvent>(HandleGameStateExit);
        }

        private void HandleGameStateEnter(GameStateEnterEvent evt)
        {
            if (evt.State == GameState.Gameplay)
                _spawner.StartSpawning();
        }

        private void HandleGameStateExit(GameStateExitEvent evt)
        {
            if (evt.State == GameState.Gameplay)
                _spawner.StopSpawning();
        }
        
    }
}