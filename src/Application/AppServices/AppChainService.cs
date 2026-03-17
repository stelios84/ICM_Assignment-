using Application.CQRS.Commands;
using Application.DTO;
namespace Application.AppServices
{

    /// <summary>
    /// While controllers typically use a dispatcher to send commands, and command handlers encapsulate the application logic for a single use case, 
    /// I have also introduced an Application Service.
    /// The Application Service acts as a coordinator for more complex scenarios, providing greater control over how multiple use cases or commands 
    /// are orchestrated.
    /// </summary>
    public class AppChainService : IAppChainService
    {
        CQRS.ICommandDispatcher _commandDispatcher;
        CQRS.Queries.IBlockChainQueries _queries;
        public AppChainService(CQRS.ICommandDispatcher commandDispatcher, CQRS.Queries.IBlockChainQueries blockChainQueries)
        {
            _commandDispatcher=commandDispatcher;
            _queries=blockChainQueries;
        }

        public async Task<List<BlockChainDto>> AddAndFetch(AddChainBlockCommand addChainBlockCommand,CancellationToken cancellationtoken)
        {
            await _commandDispatcher.DispatchAsync(addChainBlockCommand,cancellationtoken);
            
            var history = await _queries.GetBlockChainHistoryAsynch(addChainBlockCommand.Source, addChainBlockCommand.BlockChainType, cancellationtoken);
            
            return history;
        }

        public async Task AddChainBlock(AddChainBlockCommand addChainBlockCommand,CancellationToken cancellationToken)
        {
            await _commandDispatcher.DispatchAsync(addChainBlockCommand,cancellationToken);
        }
    }
}
