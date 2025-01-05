using Game.Application.GameStates;

namespace Game.Application.Commands
{
    public class LoseCommand : ICommand
    {
        private readonly GameStateManager _stateManager;

        public LoseCommand(GameStateManager stateManager)
        {
            _stateManager = stateManager;
        }
        
        public void Execute()
        {
            _stateManager.ChangeState<LoseState>();
        }
    }
}