using Game.Application.GameStates;

namespace Game.Application.Events
{
    public class GameStateExitEvent
    {
        public GameState State { get; private set; }

        public GameStateExitEvent(GameState state)
        {
            State = state;
        }
    }
}