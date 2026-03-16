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
        private IBtcRepository _btcrepository;
        private IBtcTest3Repository _btcTest3Repository;
        private IEthRepository _ethRepository;
        private ILtcRepository _ltcRepository;
        private IDashRepository _dashRepository;
        private IChainRepository _chainRepository;
        public IBtcRepository BtcRepository
        {
            get
            {
                if (_btcrepository == null)
                {
                    _btcrepository = new Infrastructure.Repositories.BTCRepository(_context);
                }
                return _btcrepository;
            }
        }


        public IBtcTest3Repository BtcTest3Repository
        {
            get
            {
                if (_btcTest3Repository == null)
                {
                    _btcTest3Repository = new BtcTest3Repository(_context);
                }
                return _btcTest3Repository;
            }
        }

        public IDashRepository DashRepository
        {
            get
            {
                if (_dashRepository == null)
                {
                    _dashRepository = new Infrastructure.Repositories.DashRepository(_context);
                }
                return _dashRepository;
            }
        }

        public IEthRepository EthRepository
        {
            get
            {
                if (_ethRepository == null)
                {
                    _ethRepository = new EthRepository(_context);
                }
                return _ethRepository;
            }
        }

        public ILtcRepository LtcRepository
        {
            get
            {
                if (_ltcRepository == null)
                {
                    _ltcRepository = new LTCRepository(_context);
                }
                return _ltcRepository;
            }
        }

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
