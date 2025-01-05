using Game.Application.Commands;
using Zenject;

namespace Game.Infrastructure.Services
{
    public class CommandMediator : ICommandMediator
    {
        private readonly DiContainer _container;

        public CommandMediator(DiContainer container)
        {
            _container = container;
        }

        public void Execute<T>() where T : ICommand
        {
            var command = _container.Resolve<T>();
            command.Execute();
        }
    }   
}