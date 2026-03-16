using Domain.Aggregates.OldAR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ILtcRepository
    {
        void Add(LTC lTC);
        Task<IEnumerable<LTC>> GetAllAsynch();
    }
}
