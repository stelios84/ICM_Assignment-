using Domain.Aggregates.OldAR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBtcTest3Repository
    {
        void Add(BTCTest3 bTCTest3);
        Task<IEnumerable<BTCTest3>> GetAllAsynch();
    }
}
