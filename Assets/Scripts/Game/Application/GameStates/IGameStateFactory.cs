namespace Game.Application.GameStates
{
    public interface IGameStateFactory
    {
        T CreateState<T>() where T : IGameState;
    }
}