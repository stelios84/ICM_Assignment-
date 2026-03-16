using Domain.Aggregates.OldAR;
using System.Collections.Generic;
 
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBtcRepository
    {
        Task<IEnumerable<BTC>> GetAllAsynch();
        void Add(BTC bTC);
      
        
    }
}
