using Game.Application.GameStates;

namespace Game.Application.Commands
{
    public class WinCommand : ICommand
    {
        private readonly GameStateManager _stateManager;

        public WinCommand(GameStateManager stateManager)
        {
            _stateManager = stateManager;
        }
        
        public void Execute()
        {
            _stateManager.ChangeState<WinState>();
        }
    }
}