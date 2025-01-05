using Game.Application.Events;
using Game.Application.GameStates;

namespace Game.Application.Commands
{
    public class PlayAgainCommand : ICommand
    {
        private readonly GameStateManager _stateManager;
        private readonly EventBus _eventBus;

        public PlayAgainCommand(GameStateManager stateManager, EventBus eventBus)
        {
            _stateManager = stateManager;
            _eventBus = eventBus;
        }
        
        public void Execute()
        {
            _eventBus.ClearAllSubscriptions();
            _stateManager.ChangeState<MainMenuState>();
        }
    }
}