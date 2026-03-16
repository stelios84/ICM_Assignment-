using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        Task<IEnumerable<T>> GetAsynch();
    }
}
