namespace Game.Application.Commands
{
    public interface ICommandMediator
    {
        public void Execute<T>() where T : ICommand;
    }
}