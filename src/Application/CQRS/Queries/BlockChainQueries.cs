using Application.DTO;
using Application.Enums;
using Application.Helpers;
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

        public async Task<List<BlockChainDto>> GetBlockChainHistoryAsynch(AppEnumSourceProvider sourceProvider, AppEnumBlockChain blockChain, CancellationToken cancellationToken)
        {
            string chainName = MappingHelper.GetChainName(sourceProvider, blockChain);
            var mylist = new List<BlockChainDto>();

            using (var dbcon = contextFactory.CreateDbContext())
            {
                //AsNoTracking to mark db we dont want track changes as will improve also the perfomance
                var data = await dbcon.Chains.AsNoTracking().Where(x => x.sourceProvider == sourceProvider.ToString() && x.Name == chainName).Select(s => new { s.Name, s.JsonApi, s.CreatedAt }).OrderByDescending(x => x.CreatedAt).ToListAsync(cancellationToken);
                mylist = data.Select(x => new BlockChainDto()
                {
                    CreatedAt = x.CreatedAt.FromUtc(),
                    JsonData = System.Text.Json.JsonSerializer.Deserialize<object>(x.JsonApi),

                }).ToList();
            }
            return mylist;
        }





    }
}
