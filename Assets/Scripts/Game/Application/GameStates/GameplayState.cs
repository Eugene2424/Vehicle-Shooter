using Game.Application.Abstractions;
using Game.Application.Events;

namespace Game.Application.GameStates
{
    public class GameplayState : EventBasedState
    {
        private readonly IAudioService _audioService;
        protected override string StateName => "GameplayState";
        protected override GameState State => GameState.Gameplay;

        public GameplayState(EventBus eventBus, ILoggerService logger, IAudioService audioService) : base(eventBus, logger)
        {
            _audioService = audioService;
        }
        
        public override void Enter()
        {
            base.Enter();
            _audioService.PlayMusic("GameplayMusic");
        }

        public override void Exit()
        {
            base.Exit();
            _audioService.StopMusic();
        }
    }
}