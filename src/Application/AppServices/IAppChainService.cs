 

namespace Application.AppServices
{
    public interface IAppChainService
    {
        /// <summary>
        /// Add current chain block to system
        /// </summary>
        Task AddChainBlock(CQRS.Commands.AddChainBlockCommand addChainBlockCommand,CancellationToken cancellationToken=default);
        

        /// <summary>
        /// This method will add the latest chain block to system and return the history back
        /// </summary>
        /// <param name="addChainBlockCommand"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Full history of given chain block</returns>
        Task<List<DTO.BlockChainDto>> AddAndFetch(CQRS.Commands.AddChainBlockCommand addChainBlockCommand, CancellationToken cancellationToken=default);
    }
}
