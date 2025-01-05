using Game.Application.Abstractions;
using Game.Application.Events;

namespace Game.Application.GameStates
{
    public class WinState : EventBasedState
    {
        private readonly IAudioService _audioService;
        protected override string StateName => "WinState";
        protected override GameState State => GameState.Win;

        public WinState(EventBus eventBus, ILoggerService logger, IAudioService audioService) : base(eventBus, logger)
        {
            _audioService = audioService;
        }
        
        public override void Enter()
        {
            base.Enter();
            _audioService.PlaySFX("WinSfx");
        }

        public override void Exit()
        {
            base.Exit();
            _audioService.StopMusic();
        }
    }
}