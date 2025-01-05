using Game.Application.Abstractions;

namespace Game.Application.GameStates
{
    public class MainMenuState : SceneBasedState
    { 
        private readonly IAudioService _audioService;
        protected override string SceneName => "Main";

        public MainMenuState(ISceneLoader sceneLoader, ILoggerService logger, IAudioService audioService)
            : base(sceneLoader, logger)
        {
            _audioService = audioService;
        }

        public override void Enter()
        {
            base.Enter();
            _audioService.PlayMusic("MainMenuMusic");
        }

        public override void Exit()
        {
            base.Exit();
            _audioService.StopMusic();
        }
    }
}