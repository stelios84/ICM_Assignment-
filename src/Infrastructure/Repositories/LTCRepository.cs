using Domain.Aggregates.OldAR;
using Infrastructure.DB.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class LTCRepository : Domain.Repositories.ILtcRepository
    {
        AppDBContext _context;
        public LTCRepository(AppDBContext context)
        {
            _context = context;
        }

        public void Add(LTC _lTC)
        {
            var toentity = new DB.Entities.LTC()
            {
                CreatedAt = _lTC.GetCreatedAt().ToUniversalTime().ToString(),
                Hash = _lTC.GetHash(),
                Height = _lTC.GetHeight(),
                High_Fee_Per_Kb = _lTC.GetHighFeePerKb(),               
                Last_Fork_Hash = _lTC.GetLastForkHash(),
                Last_Fork_Height = _lTC.GetLastForkHeight(),
                Latest_Url = _lTC.GetLatestUrl(),
                Low_Fee_Per_Kb = _lTC.GetLowFeePerKb(),
                Medium_Fee_Per_Kb = _lTC.GetMediumFeePerKb(),
                Name = _lTC.GetName(),
                Peer_Count = _lTC.GetPeerCount(),
                Previous_Hash = _lTC.GetPreviousHash(),
                Previous_Url = _lTC.GetPreviousUrl(),
                Time = _lTC.GetTime().ToUniversalTime().ToString(),
                Unconfirmed_Count = _lTC.GetUnconfirmedCount(),
                JsonApi=_lTC.GetJsonApi()
            };
            _context.LtcChain.Add(toentity);
        }

      
        public async Task<IEnumerable<LTC>> GetAllAsynch()
        {
            var _entities = await _context.LtcChain.ToListAsync();
            var todomain = _entities.Select(x => new Domain.Aggregates.OldAR.LTC(x.Name, x.Height, x.Hash, x.Time.FromUtc(), x.Latest_Url, x.Previous_Hash, x.Previous_Url,
                x.Peer_Count, x.Unconfirmed_Count.GetValueOrDefault(), 
                x.High_Fee_Per_Kb.GetValueOrDefault(), 
                x.Medium_Fee_Per_Kb.GetValueOrDefault() , 
                x.Low_Fee_Per_Kb.GetValueOrDefault(), 
                x.Last_Fork_Height.GetValueOrDefault(), x.Last_Fork_Hash, x.CreatedAt.FromUtc(),x.JsonApi));


            return todomain;
        }
    }
}
