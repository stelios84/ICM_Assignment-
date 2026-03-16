using Domain.Aggregates.OldAR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IDashRepository
    {

        void Add(Dash dash);
        Task<IEnumerable<Dash>> GetAllAsynch();

    }
}
