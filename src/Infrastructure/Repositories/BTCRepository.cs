using Domain.Aggregates.OldAR;
using Domain.Repositories;
using Infrastructure.DB.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BTCRepository:IBtcRepository 
    {
        AppDBContext _context;
        public BTCRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Add(BTC _bTC)
        {
            //convert to entity
            var entity = new DB.Entities.BTC()
            {
                Name = _bTC.GetName(),
                CreatedAt = _bTC.GetCreatedAt().ToUniversalTime().ToString("o"),
                Hash = _bTC.GetHash(),
                Height = _bTC.GetHeight(),
                High_Fee_Per_Kb = _bTC.GetHighFeePerKb(),
                Last_Fork_Hash = _bTC.GetLastForkHash(),
                Last_Fork_Height = _bTC.GetLastForkHeight(),
                Latest_Url = _bTC.GetLatestUrl(),
                Low_Fee_Per_Kb = _bTC.GetLowFeePerKb(),
                Medium_Fee_Per_Kb = _bTC.GetMediumFeePerKb(),
                Peer_Count = _bTC.GetPeerCount(),
                Previous_Hash = _bTC.GetPreviousHash(),
                Previous_Url = _bTC.GetPreviousUrl(),
                Time = _bTC.GetTime().ToUniversalTime().ToString("o"),
                Unconfirmed_Count = _bTC.GetUnconfirmedCount(),
                JsonApi=_bTC.GetJsonApi()
            };
            _context.BtcChain.Add(entity);
        }

     
        public async Task<IEnumerable<BTC>> GetAllAsynch()
        {
            var getall = await _context.BtcChain.ToListAsync();
            var todomain = getall.Select(x => new Domain.Aggregates.OldAR.BTC(x.Name, x.Height, x.Hash, x.Time.FromUtc(), x.Latest_Url, x.Previous_Hash, x.Previous_Url,
                x.Peer_Count, x.Unconfirmed_Count.GetValueOrDefault(), x.High_Fee_Per_Kb.GetValueOrDefault(), x.Medium_Fee_Per_Kb.GetValueOrDefault(), 
                x.Low_Fee_Per_Kb.GetValueOrDefault(), x.Last_Fork_Height.GetValueOrDefault(), x.Last_Fork_Hash, x.CreatedAt.FromUtc(),x.JsonApi));

            return todomain;
        }

        

        public Task<IEnumerable<BTC>> GetAsynch()
        {
            throw new NotImplementedException();
        }
    }
}
