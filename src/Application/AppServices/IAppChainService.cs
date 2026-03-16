 

namespace Application.AppServices
{
    public interface IAppChainService
    {
        Task AddChainBlock(CQRS.Commands.AddChainBlockCommand addChainBlockCommand,CancellationToken cancellationToken=default);
        Task<List<DTO.BlockChainDto>> AddAndFetch(CQRS.Commands.AddChainBlockCommand addChainBlockCommand, CancellationToken cancellationToken=default);
    }
}
