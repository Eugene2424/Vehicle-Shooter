using System;
using Game.Application.Abstractions;
using Game.Application.Events;
using Game.Application.GameStates;

namespace Game.Application.Gameplay
{
    public class GameplayUIPresenter : IPresenter
    {
        private readonly IGameplayUIView _view;
        private readonly IDistanceProgressProvider _distanceProgress;
        private readonly EventBus _eventBus;

        public GameplayUIPresenter(IGameplayUIView view, IDistanceProgressProvider distanceProgress, EventBus eventBus)
        {
            _view = view;
            _distanceProgress = distanceProgress;
            _eventBus = eventBus;
        }

        public void Initialize()
        {
            _eventBus.Subscribe<GameStateEnterEvent>(HandleGameStateEnter);
            _eventBus.Subscribe<GameStateExitEvent>(HandleGameStateExit);
            _distanceProgress.OnDistanceProgressChanged += HandleDistanceProgressChanged;
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<GameStateEnterEvent>(HandleGameStateEnter);
            _eventBus.Unsubscribe<GameStateExitEvent>(HandleGameStateExit);
            _distanceProgress.OnDistanceProgressChanged -= HandleDistanceProgressChanged;
        }

        private void HandleGameStateEnter(GameStateEnterEvent evt)
        {
            if (evt.State == GameState.Gameplay)
            {
                _view.SetMaxDistance(_distanceProgress.GetDistance());
                _view.Show();
            }
        }
        
        private void HandleGameStateExit(GameStateExitEvent evt)
        {
            if (evt.State == GameState.Gameplay)
            {
                _view.Hide();
            }
        }
        
        private void HandleDistanceProgressChanged(float value)
        {
            _view.SetDistanceProgress(value);
        }
        
    }
}