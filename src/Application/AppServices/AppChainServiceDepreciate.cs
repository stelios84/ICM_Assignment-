using Application.DTO;
using Application.Enums;
using Domain.Providers;
using Domain.Repositories;
using Infrastructure;

namespace Application.AppServices
{


    public class AppChainServiceDepreciate : IAppChainServiceDepreciate
    {
        IUnitOfWork _uof;
        IChainProvider _chainProvider;
        AppEnumSourceProvider _defaultprovider;
        IProviderFactory _providerFactory;
        CQRS.ICommandDispatcher _commandDispatcher;

        public AppChainServiceDepreciate(IUnitOfWork uof, IChainProvider chainProvider, CQRS.ICommandDispatcher commandDispatcher, IProviderFactory providerFactory)
        {
            _uof = uof;
            _chainProvider = chainProvider;
            _commandDispatcher = commandDispatcher;
            _providerFactory = providerFactory;
        }


        public async Task<IEnumerable<BTCDto>> GetBTCAsynch()
        {

            var current = await _chainProvider.GetBtcMainAsync();
            string _json = System.Text.Json.JsonSerializer.Serialize(current);


            //convert to domain           
            var btcDomain = new Domain.Aggregates.OldAR.BTC(current.name, current.height, current.hash, current.time.FromUtc(),
                current.latest_url, current.previous_hash, current.previous_url, current.peer_count, current.unconfirmed_count,
                current.high_fee_per_kb, current.medium_fee_per_kb, current.low_fee_per_kb, current.last_fork_height, current.last_fork_hash,
                DateTime.Now, _json);

            _uof.BtcRepository.Add(btcDomain);
            _uof.Commit();


            var alldata = await _uof.BtcRepository.GetAllAsynch();

            var todtodata = alldata.Select(x => Mappers.DtoMapper.ToBtcDto(x)).OrderByDescending(x => x.CreatedAt);
            return todtodata;


        }

        public async Task<IEnumerable<BtcTest3DTO>> GetBtcTest3Asynch()
        {
            var current = await _chainProvider.GetBtcTest3SourceAsync();
            string _json = System.Text.Json.JsonSerializer.Serialize(current);

            //convert to domain
            var btcDomain = new Domain.Aggregates.OldAR.BTCTest3(current.name, current.height, current.hash, current.time.FromUtc(),
                current.latest_url, current.previous_hash, current.previous_url, current.peer_count, current.unconfirmed_count,
                current.high_fee_per_kb, current.medium_fee_per_kb, current.low_fee_per_kb, current.last_fork_height, current.last_fork_hash,
                DateTime.Now, _json);

            _uof.BtcTest3Repository.Add(btcDomain);
            _uof.Commit();

            //fetch all history
            var alldata = await _uof.BtcTest3Repository.GetAllAsynch();

            //domain -> dto 
            var dtolist = alldata.Select(x => Mappers.DtoMapper.ToBtcTest3DTO(x)).OrderByDescending(x => x.CreatedAt);
            return dtolist;
        }

        public async Task<IEnumerable<DashDTO>> GetDashAsynch()
        {
            var current = await _chainProvider.GetDashSourceAsync();
            string _json = System.Text.Json.JsonSerializer.Serialize(current);

            //convert to domain
            var todomain = new Domain.Aggregates.OldAR.Dash(current.name, current.height, current.hash, current.time.FromUtc(),
                current.latest_url, current.previous_hash, current.previous_url, current.peer_count, current.unconfirmed_count,
                current.high_fee_per_kb, current.medium_fee_per_kb, current.low_fee_per_kb, current.last_fork_height, current.last_fork_hash,
                DateTime.Now, _json);

            _uof.DashRepository.Add(todomain);
            _uof.Commit();
            var alldata = await _uof.DashRepository.GetAllAsynch();

            var toDtoList = alldata.Select(x => Mappers.DtoMapper.ToDashDTO(x)).OrderByDescending(x => x.CreatedAt);
            return toDtoList;
        }

        public async Task<IEnumerable<EthDTO>> GetEthAsynch()
        {
            var current = await _chainProvider.GetEthAsynch();
            string _json = System.Text.Json.JsonSerializer.Serialize(current);

            //convert to domain
            var todomain = new Domain.Aggregates.OldAR.EthChain(current.name, current.height, current.hash, current.time.FromUtc(), current.latest_url,
                current.previous_hash, current.previous_url, current.peer_count, current.unconfirmed_count, current.high_gas_price, current.medium_gas_price,
                current.low_gas_price, current.high_priority_fee, current.medium_priority_fee, current.low_priority_fee, current.base_fee, current.last_fork_height,
                current.last_fork_hash, DateTime.Now, _json);

            _uof.EthRepository.Add(todomain);
            _uof.Commit();
            var alldata = await _uof.EthRepository.GetAllAsynch();
            var todtolist = alldata.Select(x => Mappers.DtoMapper.ToEthDTO(x)).OrderByDescending(x => x.CreatedAt);
            return todtolist;
        }

        public async Task<IEnumerable<LtcDTO>> GetLtcAsynch()
        {
            var current = await _chainProvider.GetLtcSourceAsync();
            string _json = System.Text.Json.JsonSerializer.Serialize(current);

            //convert to domain
            var todomain = new Domain.Aggregates.OldAR.LTC(current.name, current.height, current.hash, current.time.FromUtc(), current.latest_url, current.previous_hash, current.previous_url,
                current.peer_count, current.unconfirmed_count, current.high_fee_per_kb, current.medium_fee_per_kb, current.low_fee_per_kb, current.last_fork_height, current.last_fork_hash,
                DateTime.Now, _json);

            _uof.LtcRepository.Add(todomain);
            _uof.Commit();
            var alldata = await _uof.LtcRepository.GetAllAsynch();
            var todtolist = alldata.Select(x => Mappers.DtoMapper.ToLtcDTO(x)).OrderByDescending(x => x.CreatedAt);
            return todtolist;
        }
       
    }

}
