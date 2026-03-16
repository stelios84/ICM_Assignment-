using Application.AppServices;
using Application.CQRS;
using Application.CQRS.Commands;
using Application.DTO;
using Domain.Aggregates.ChainAR;
using Domain.Repositories;


namespace XUnitAppTests.ApplicationTest
{
    public class Test
    {

        [Fact]
        public async Task TestApplicationService()
        {
            var mockrepo = new MockChainRepository();
            var mockUof = new MockUOF(mockrepo);
            var mocksourceprovider = new MockSourceProvider();
            var mockDispatcher = new MockCommandDispatcher();
            var appser = new MockAppService();

            var cmd = new Application.CQRS.Commands.AddChainBlockCommand(EnumBlockType.btc_main, DateTime.Now, Application.Enums.AppEnumSourceProvider.Blockcypher);

            //add and fetch in one
            var dtoresults = await appser.AddAndFetch(cmd);

            Assert.True(dtoresults.Count > 0);


            cmd.BlockChainType = EnumBlockType.dash_main;
            //add block chain
            await appser.AddChainBlock(cmd);
        }


    }
    public class MockAppService : IAppChainService
    {
        public async Task<List<BlockChainDto>> AddAndFetch(AddChainBlockCommand addChainBlockCommand, CancellationToken cancellationToken = default)
        {
            //add fetch 
            await Task.Delay(1);
            var data = new List<BlockChainDto>();
            data.Add(new BlockChainDto()
            {
                CreatedAt = DateTime.Now,
                JsonData = @"{
  ""name"": ""BTC.main"",
  ""height"": 940688,
  ""hash"": ""00000000000000000001f08d0016eef16cc0fc814d12a658cb12c4e8cf9e9ac6"",
  ""time"": ""2026-03-14T22:17:36.978433885Z"",
  ""latest_url"": ""https://api.blockcypher.com/v1/btc/main/blocks/00000000000000000001f08d0016eef16cc0fc814d12a658cb12c4e8cf9e9ac6"",
  ""previous_hash"": ""000000000000000000015398c92413122f0176245f2930f55d63af38c35779c1"",
  ""previous_url"": ""https://api.blockcypher.com/v1/btc/main/blocks/000000000000000000015398c92413122f0176245f2930f55d63af38c35779c1"",
  ""peer_count"": 323,
  ""unconfirmed_count"": 2932,
  ""high_fee_per_kb"": 2833,
  ""medium_fee_per_kb"": 1726,
  ""low_fee_per_kb"": 1378,
  ""last_fork_height"": 935976,
  ""last_fork_hash"": ""00000000000000000000626a49c9c9047fb8b49a8216daf5e448d44517d38a55""
}"
            });

            return data;
        }

        public async Task AddChainBlock(AddChainBlockCommand addChainBlockCommand, CancellationToken cancellationToken = default)
        {
            await Task.FromResult(0);
        }
    }
    public class MockCommandDispatcher : Application.CQRS.ICommandDispatcher
    {
        public Task DispatchAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand
        {
            throw new NotImplementedException();
        }
    }

    public class MockSourceProvider : Domain.Providers.ISourceProvider
    {
        public Task<string> GetBtcMainAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetBtcTest3SourceAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetDASHAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetETHAsynch(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetLTCSourceAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
    public class MockAppChainService : Application.AppServices.IAppChainService
    {
        public async Task<List<BlockChainDto>> AddAndFetch(AddChainBlockCommand addChainBlockCommand, CancellationToken cancellationToken = default)
        {
            await Task.Delay(1);
            return new List<BlockChainDto>();
        }

        public async Task AddChainBlock(AddChainBlockCommand addChainBlockCommand, CancellationToken cancellationToken = default)
        {
            await Task.Delay(1);
        }
    }
    public class MockChainRepository : IChainRepository
    {
        public Task AddAsynch(BlockChain baseChain)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BlockChain>> GetAllAsynch()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BlockChain>> GetByProvider(string name)
        {
            throw new NotImplementedException();
        }
    }
    public class MockUOF : IUnitOfWork
    {
        IChainRepository _chainrepository;

        public MockUOF(IChainRepository chainrepository)
        {
            _chainrepository = chainrepository;
        }

        public IBtcTest3Repository BtcTest3Repository => throw new NotImplementedException();

        public IDashRepository DashRepository => throw new NotImplementedException();

        public IEthRepository EthRepository => throw new NotImplementedException();

        public ILtcRepository LtcRepository => throw new NotImplementedException();

        public IChainRepository ChainRepository => _chainrepository;

        public IBtcRepository BtcRepository => throw new NotImplementedException();

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
