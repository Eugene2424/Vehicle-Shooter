using Game.Application.Abstractions;
using Game.Application.Events;

namespace Game.Application.GameStates
{
    public abstract class EventBasedState : IGameState
    {
        private readonly EventBus _eventBus;
        private readonly ILoggerService _logger;
        
        protected abstract GameState State { get; }
        protected abstract string StateName { get; }

        public EventBasedState(EventBus eventBus, ILoggerService logger)
        {
            _eventBus = eventBus;
            _logger = logger;
        }
        
        
        public virtual void Enter()
        {
            _eventBus.Publish(new GameStateEnterEvent(State));
            _logger.Log("Entering " + StateName + " state");
        }

        public virtual void Exit()
        {
            _eventBus.Publish(new GameStateExitEvent(State));
            _logger.Log("Exiting " + StateName + " state");
        }
    }
}