
using Domain.Aggregates.OldAR;
using System.Collections.Generic;
 
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IEthRepository
    {
        Task<IEnumerable<EthChain>> GetAllAsynch();

        void Add(EthChain ethChain);
    }
}
