using Infrastructure.DB.DBContext;

namespace Infrastructure.DB
{
    internal class UnitOfWork : Domain.Repositories.IUnitOfWork
    {
        AppDBContext _dbcontext;
        public UnitOfWork(AppDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Commit()
        {
            _dbcontext.SaveChanges();
        }
    }
}
