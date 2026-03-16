using Domain.Aggregates.ChainAR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IChainRepository
    {
        Task<IEnumerable<BlockChain>> GetAllAsynch();
        Task<IEnumerable<BlockChain>> GetByProvider(string name);
        Task AddAsynch(BlockChain baseChain);

    }
}
