using Domain.Aggregates.OldAR;
using Infrastructure.DB.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class DashRepository : Domain.Repositories.IDashRepository
    {
        AppDBContext _context;
        public DashRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Add(Dash dash)
        {

            var todomain = new DB.Entities.Dash()
            {
                CreatedAt = dash.GetCreatedAt().ToUniversalTime().ToString(),
                hash = dash.GetHash(),
                height = dash.GetHeight(),
                high_fee_per_kb = dash.GetHighFeePerKb(),
                last_fork_hash = dash.GetLastForkHash(),
                last_fork_height = dash.GetLastForkHeight(),
                latest_url = dash.GetLatestUrl(),
                low_fee_per_kb = dash.GetLowFeePerKb(),
                medium_fee_per_kb = dash.GetMediumFeePerKb(),
                name = dash.GetName(),
                peer_count = dash.GetPeerCount(),
                previous_hash = dash.GetPreviousHash(),
                previous_url = dash.GetPreviousUrl(),
                time = dash.GetTime().ToUniversalTime().ToString("o"),
                unconfirmed_count = dash.GetUnconfirmedCount(),
                JsonApi=dash.GetJsonApi()
            };

            _context.Dash.Add(todomain);
        }
 
        public async Task<IEnumerable<Dash>> GetAllAsynch()
        {
            var _entities = await _context.Dash.ToListAsync();
            var todomain = _entities.Select(x => new Domain.Aggregates.OldAR.Dash( x.name, x.height, x.hash, x.time.FromUtc(), x.latest_url, x.previous_hash, x.previous_url,
                x.peer_count, x.unconfirmed_count.GetValueOrDefault(),
                x.high_fee_per_kb.GetValueOrDefault(),
                x.medium_fee_per_kb.GetValueOrDefault(),
                x.low_fee_per_kb.GetValueOrDefault(),
                x.last_fork_height.GetValueOrDefault(),
                x.last_fork_hash, x.CreatedAt.FromUtc(),x.JsonApi));

            return todomain;
        }
    }
}
