namespace Application.CQRS.Queries
{
    public interface IBlockChainQueries
    {
        Task<List<DTO.BlockChainDto>> GetBlockChainHistoryAsynch(string blocktype,CancellationToken cancellationToken);

        Task<List<DTO.BlockChainDto>> GetBlockChainHistoryAsynch(Application.Enums.AppEnumSourceProvider sourceProvider, 
            Application.Enums.AppEnumBlockChain block , CancellationToken cancellationToken);

    }
}
