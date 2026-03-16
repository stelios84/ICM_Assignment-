using Microsoft.Extensions.DependencyInjection;


namespace Application.CQRS
{
    public class CommandDispatcher : ICommandDispatcher
    {
        IServiceProvider _sp;
        public CommandDispatcher(IServiceProvider sp)
        {
            _sp = sp;
        }

        public async Task DispatchAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand
        {

            var handler = _sp.GetRequiredService<ICommandHandler<TCommand>>();
            await handler.Handle(command);

        }
    }
}
