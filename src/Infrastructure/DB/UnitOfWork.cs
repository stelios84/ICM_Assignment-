using Domain.Repositories;
using Infrastructure.DB.DBContext;
using Infrastructure.Repositories;

namespace Infrastructure.DB
{
    public class UnitOfWork : Domain.Repositories.IUnitOfWork
    {
        AppDBContext _context;
        public UnitOfWork(AppDBContext context)
        {
            _context = context;
        }
        
        private IChainRepository _chainRepository;
        
       
        
        public IChainRepository ChainRepository
        {
            get
            {
                if (_chainRepository == null)
                {
                    _chainRepository = new Infrastructure.Repositories.ChainRepository(_context);
                }
                return _chainRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
