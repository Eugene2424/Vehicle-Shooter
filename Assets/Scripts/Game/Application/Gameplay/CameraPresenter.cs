using System;
using Game.Application.Abstractions;
using Game.Application.Events;
using Game.Application.GameStates;

namespace Game.Application.Gameplay
{
    public class CameraPresenter : IPresenter
    {
        private readonly EventBus _eventBus;
        private readonly ICameraView _cameraView;
        
        public CameraPresenter(EventBus eventBus, ICameraView cameraView)
        {
            _eventBus = eventBus;
            _cameraView = cameraView;
        }

        public void Initialize()
        {
            _eventBus.Subscribe<GameStateEnterEvent>(HandleGameStateEnterEvent);
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<GameStateEnterEvent>(HandleGameStateEnterEvent);
        }

        private void HandleGameStateEnterEvent(GameStateEnterEvent evt)
        {
            if (evt.State == GameState.Gameplay)
            {
                _cameraView.SwitchToFollowView();
            }
            
            else if (evt.State == GameState.Win || evt.State == GameState.Lose)
                _cameraView.SwitchToSideView();
            
        }
        
    }
}