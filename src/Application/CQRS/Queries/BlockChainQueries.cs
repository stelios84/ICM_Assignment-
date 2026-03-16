using Application.DTO;
using Application.Enums;
using Infrastructure;
using Microsoft.EntityFrameworkCore; 

namespace Application.CQRS.Queries
{
    public class BlockChainQueries : IBlockChainQueries
    {
        Infrastructure.DB.DBContext.AppDBContext _context;
        IDbContextFactory<Infrastructure.DB.DBContext.AppDBContext> contextFactory;


        /// <summary>
        /// For demonstration purposes both a DbContext instance and an IDbContextFactory are injected.
        ///
        /// _context:
        /// Using a shared scoped DbContext means multiple queries may attempt to use the same
        /// DbContext instance concurrently, which can cause runtime errors because DbContext
        /// is not thread-safe.
        ///
        /// _contextFactory:
        /// Each query creates its own DbContext instance, allowing queries to run safely
        /// and independently without concurrency issues.
        /// </summary>
        public BlockChainQueries(Infrastructure.DB.DBContext.AppDBContext context, IDbContextFactory<Infrastructure.DB.DBContext.AppDBContext> contextFactory)
        {
            _context = context;
            this.contextFactory = contextFactory;
        }


        /// <summary>
        /// Improvments
        /// chainBlockName could be an enum. 
        /// we could pass also the provider source
        /// </summary>
        public async Task<List<BlockChainDto>> GetBlockChainHistoryAsynch(string chainBlockName, CancellationToken cancellationToken)
        {
            using (var dbcon = contextFactory.CreateDbContext())
            {
                var data = await dbcon.Chains.Where(x => x.Name == chainBlockName).Select(s => new { s.Name, s.JsonApi, s.CreatedAt }).OrderByDescending(x => x.CreatedAt).ToListAsync(cancellationToken);
                var todto = data.Select(x => new BlockChainDto()
                {
                    CreatedAt = x.CreatedAt.FromUtc(),
                    JsonData = System.Text.Json.JsonSerializer.Deserialize<object>(x.JsonApi)
                });
                return todto.ToList();

            }
        }
        string GetBlockChainName(AppEnumBlockChain fromType)
        {
            switch (fromType)
            {
                case AppEnumBlockChain.eth_main:
                    return "ETH.main";
                case AppEnumBlockChain.dash_main:
                    return "DASH.main";
                case AppEnumBlockChain.btc_main:
                    return "BTC.main";
                case AppEnumBlockChain.btc_test3:
                    return "BTC.test3";
                case AppEnumBlockChain.ltc_main:
                    return "LTC.main";
            }

            throw new KeyNotFoundException();
        }
        public async Task<List<BlockChainDto>> GetBlockChainHistoryAsynch(AppEnumSourceProvider sourceProvider, AppEnumBlockChain block, CancellationToken cancellationToken)
        {
            using(var dbcon=contextFactory.CreateDbContext())
            {
                var data = await dbcon.Chains.Where(x => x.sourceProvider== sourceProvider.ToString() && x.Name == GetBlockChainName(block)).Select(s => new { s.Name, s.JsonApi, s.CreatedAt }).OrderByDescending(x => x.CreatedAt).ToListAsync(cancellationToken);
                var todto = data.Select(x => new BlockChainDto()
                {
                    CreatedAt = x.CreatedAt.FromUtc(),
                    JsonData = System.Text.Json.JsonSerializer.Deserialize<object>(x.JsonApi),

                });

                //var list2 = new List<BlockChainDto>();

                //foreach(var d in data)
                //{
                //    var jo = System.Text.Json.Nodes.JsonObject.Parse(data.First().JsonApi);                    
                //    jo["CreatedAt"] = d.CreatedAt;

                //    list2.Add(new BlockChainDto()
                //    {
                //        CreatedAt = d.CreatedAt.FromUtc(),
                //        JsonData = System.Text.Json.JsonSerializer.Deserialize<object>(jo.ToJsonString())
                //    });
                //}

                //return list2;
                return todto.ToList();

            }
            throw new NotImplementedException();
        }
    }
}
