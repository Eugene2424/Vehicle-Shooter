using Game.Application.Abstractions;
using Game.Application.Events;

namespace Game.Application.GameStates
{
    public class LoseState : EventBasedState
    {
        private readonly IAudioService _audioService;
        protected override string StateName => "LoseState";
        protected override GameState State => GameState.Lose;

        public LoseState(EventBus eventBus, ILoggerService logger, IAudioService audioService) : base(eventBus, logger)
        {
            _audioService = audioService;
        }
        
        public override void Enter()
        {
            base.Enter();
            _audioService.PlaySFX("LoseSfx");
        }

        public override void Exit()
        {
            base.Exit();
            _audioService.StopMusic();
        }
    }
}