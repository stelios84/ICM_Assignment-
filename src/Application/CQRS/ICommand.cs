

namespace Application.CQRS
{
    public interface ICommand
    {
    }

    public interface ICommandHandler<Command>
    {
        Task Handle(Command command);

    }

    public interface ICommandDispatcher
    {
        Task DispatchAsync<TCommand>(TCommand command,
       CancellationToken cancellationToken = default) where TCommand : ICommand;
    }
}
