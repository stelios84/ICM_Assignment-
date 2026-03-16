using Domain.Aggregates.OldAR;
using Infrastructure.DB.DBContext;
using Infrastructure.DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class EthRepository : Domain.Repositories.IEthRepository
    {
        AppDBContext _context;
        public EthRepository(AppDBContext appDBContext)
        {
            _context = appDBContext;
        }

        public void Add(EthChain ethChain)
        {
            var toentity = new DB.Entities.Eth()
            {

                name = ethChain.GetName(),
                hash = ethChain.GetHash(),
                CreatedAt = ethChain.GetCreatedAt().ToString(),
                height = ethChain.GetHeight(),
                last_fork_hash = ethChain.GetLastForkHash(),
                last_fork_height = ethChain.GetLastForkHeight(),
                latest_url = ethChain.GetLatestUrl(),
                peer_count = ethChain.GetPeerCount(),
                previous_hash = ethChain.GetPreviousHash(),
                previous_url = ethChain.GetPreviousUrl(),
                time = ethChain.GetTime().ToUniversalTime().ToString(),
                unconfirmed_count = ethChain.GetUnconfirmedCount(),
                base_fee = ethChain.GetBaseFee(),
                high_gas_price = ethChain.GetHighGasPrice(),
                high_priority_fee = ethChain.GetHighPriorityFee(),
                low_gas_price = ethChain.GetLowGasPrice(),
                low_priority_fee = ethChain.GetLowPriorityFee(),
                medium_gas_price = ethChain.GetMediumGasPrice(),
                medium_priority_fee = ethChain.GetMediumPriorityFee(),
                JsonApi=ethChain.GetJsonApi()
            };

            _context.EthChain.Add(toentity);
        }

      
        public async Task<IEnumerable<EthChain>> GetAllAsynch()
        {
            var entities = await _context.EthChain.ToListAsync();
            var todomain = entities.Select(x => new Domain.Aggregates.OldAR.EthChain(x.name, x.height, x.hash, x.time.FromUtc(), x.latest_url,
                x.previous_hash, x.previous_url, x.peer_count, x.unconfirmed_count, x.high_gas_price, x.medium_gas_price, x.low_gas_price, x.high_priority_fee,
                x.medium_priority_fee, x.low_priority_fee, x.base_fee, x.last_fork_height, x.last_fork_hash,x.CreatedAt.FromUtc(),x.JsonApi));

            return todomain;
        }
    }
}
