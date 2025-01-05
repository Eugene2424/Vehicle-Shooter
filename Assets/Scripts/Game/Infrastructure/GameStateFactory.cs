using Game.Application;
using Game.Application.GameStates;
using Zenject;

namespace Game.Infrastructure
{
    public class GameStateFactory : IGameStateFactory
    {
        private readonly DiContainer _container;

        public GameStateFactory(DiContainer container)
        {
            _container = container;
        }
        
        public T CreateState<T>() where T : IGameState
        {
            return _container.Resolve<T>();
        }
    }
}