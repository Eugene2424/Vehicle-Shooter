using Game.Application.GameStates;

namespace Game.Application.Commands
{
    public class StartPlayingCommand : ICommand
    {
        private readonly GameStateManager _stateManager;

        public StartPlayingCommand(GameStateManager stateManager)
        {
            _stateManager = stateManager;
        }
        
        public void Execute()
        {
            _stateManager.ChangeState<GameplayState>();
        }
    }
}