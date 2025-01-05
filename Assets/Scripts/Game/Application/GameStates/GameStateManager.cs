namespace Game.Application.GameStates
{
    public enum GameState
    {
        None = 0,
        MainMenu = 1,
        Gameplay = 2,
        Win = 3,
        Lose = 4
    }
    
    public class GameStateManager
    {
        private IGameState _currentState;
        private readonly IGameStateFactory _stateFactory;

        public GameStateManager(IGameStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }
        
        public void ChangeState<T>() where T : IGameState
        {
            _currentState?.Exit();
            _currentState = _stateFactory.CreateState<T>();
            _currentState?.Enter();
        }
        
    }
}