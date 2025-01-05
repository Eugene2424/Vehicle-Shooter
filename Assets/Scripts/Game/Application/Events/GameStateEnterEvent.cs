using Game.Application.GameStates;

namespace Game.Application.Events
{
    public class GameStateEnterEvent
    {
        public GameState State { get; private set; }

        public GameStateEnterEvent(GameState state)
        {
            State = state;
        }
    }
}