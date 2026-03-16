using Domain.Aggregates.ChainAR;
using Domain.Repositories;
using Infrastructure.DB.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ChainRepository : IChainRepository
    {
        AppDBContext _context;
        public ChainRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task AddAsynch(BlockChain baseChain)
        {
            var toentity = new DB.Entities.Chain()
            {
                Name = baseChain.GetName(),
                CreatedAt = baseChain.GetCreatedAt().ToUTcDate(),
                JsonApi = baseChain.GetJsonApi(),
                sourceProvider=baseChain.Source.ToString()
            };
           await _context.Chains.AddAsync(toentity);
        }

        Domain.Providers.EnumSourceProvider GetSource(string name)
        {
            if (name == "Blockcypher")
                return  Domain.Providers.EnumSourceProvider.Blockcypher;
            throw new KeyNotFoundException();
        }
        public async Task<IEnumerable<BlockChain>> GetAllAsynch()
        {
            var allchains = await _context.Chains.ToListAsync();
            var todomain = allchains.Select(x => new Domain.Aggregates.ChainAR.BlockChain(GetSource(x.sourceProvider), x.Name, x.CreatedAt.FromUtc(), x.JsonApi));
            return todomain;
        }

        public async Task<IEnumerable<BlockChain>> GetByProvider(string name)
        {
            var blockchainEntitiesByName = await _context.Chains.Where(x => x.Name == name).ToListAsync();
            var todomain = blockchainEntitiesByName.Select(x => new Domain.Aggregates.ChainAR.BlockChain(GetSource(x.sourceProvider), x.Name, x.CreatedAt.FromUtc(), x.JsonApi));
            return todomain;
            
        }

       
         

    }
}
