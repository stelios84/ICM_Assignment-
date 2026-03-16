using Domain.Aggregates.OldAR;
using Infrastructure.DB.DBContext;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories
{
    public class BtcTest3Repository : Domain.Repositories.IBtcTest3Repository
    {
        AppDBContext _context;
        public BtcTest3Repository(AppDBContext context)
        {
            _context = context;
        }

        public void Add(BTCTest3 bTCTest3)
        {
            var toentity = new DB.Entities.BTCTest3()
            {
                name = bTCTest3.GetName(),
                hash = bTCTest3.GetHash(),
                CreatedAt = bTCTest3.GetCreatedAt().ToUniversalTime().ToString(),
                height = bTCTest3.GetHeight(),
                high_fee_per_kb = bTCTest3.GetHighFeePerKb(),
                last_fork_hash = bTCTest3.GetLastForkHash(),
                last_fork_height = bTCTest3.GetLastForkHeight(),
                latest_url = bTCTest3.GetLatestUrl(),
                low_fee_per_kb = bTCTest3.GetLowFeePerKb(),
                medium_fee_per_kb = bTCTest3.GetMediumFeePerKb(),
                peer_count = bTCTest3.GetPeerCount(),
                previous_hash = bTCTest3.GetPreviousHash(),
                previous_url = bTCTest3.GetPreviousUrl(),
                time = bTCTest3.GetTime().ToUniversalTime().ToString(),
                unconfirmed_count = bTCTest3.GetUnconfirmedCount(),
                JsonApi=bTCTest3.GetJsonApi()
            };

            _context.BtcChainTest3.Add(toentity);
        }
      
        public async Task<IEnumerable<BTCTest3>> GetAllAsynch()
        {
            var data = await _context.BtcChainTest3.ToListAsync();

            var todomain = data.Select(x => new Domain.Aggregates.OldAR.BTCTest3( x.name, x.height, x.hash, x.time.FromUtc(), x.latest_url,
                x.previous_hash, x.previous_url, x.peer_count, x.unconfirmed_count, x.high_fee_per_kb, x.medium_fee_per_kb, x.low_fee_per_kb,
                x.last_fork_height, x.last_fork_hash, x.CreatedAt.FromUtc(),x.JsonApi));

            return todomain;
        }
    }
}
