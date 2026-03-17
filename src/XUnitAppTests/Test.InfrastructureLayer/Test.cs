using Domain.Aggregates.ChainAR;
using Domain.Providers;
using Microsoft.EntityFrameworkCore;

namespace XUnitAppTests.Test.InfrastructureLayer
{
    public class Test
    {

        [Fact]
       public async Task TestRepository()
        {
            var options = new DbContextOptionsBuilder<Infrastructure.DB.DBContext.AppDBContext>()
        .UseSqlite("DataSource=mydb.sqlite")
        .Options;

            using var context = new Infrastructure.DB.DBContext.AppDBContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var blockcypherprovider = new Infrastructure.Providers.BlockCypherProvider(new HttpClient());
            

            var repo = new Infrastructure.Repositories.ChainRepository(context);

            var _btcMainJsonResult = await blockcypherprovider.GetChainBlock(BlockCypherchaineType.Btc_Main);
            var chain = new BlockChain(EnumSourceProvider.Blockcypher, "BTC.main", DateTime.Now, _btcMainJsonResult);

            await repo.AddAsynch(chain);
            await context.SaveChangesAsync();

            var result = await context.Chains.FirstAsync();

            Assert.Equal("BTC.main", result.Name);
        }
    }
}
