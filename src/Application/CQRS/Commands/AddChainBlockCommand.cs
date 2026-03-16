using Application.Enums;
using Domain.Aggregates.ChainAR;
using Domain.Providers;
using Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Commands
{
  
    public class AddChainBlockCommand : ICommand
    {

        public AppEnumBlockChain BlockChainType { get; set; }
        public DateTime CreatedAt { get; set; }

       // public EnumSourceProvider Source { get; set; }
        public AppEnumSourceProvider Source { get; set; }

        public AddChainBlockCommand(AppEnumBlockChain blockType, DateTime createdAt, AppEnumSourceProvider source)
        {
            BlockChainType = blockType;
            CreatedAt = createdAt;
            Source = source;
        }
    }

    class AddChaineBlockCommandHandler : ICommandHandler<AddChainBlockCommand>
    {


        IUnitOfWork _unitOfWork;
        IProviderFactory _providerFactory;
        ILogger<AddChaineBlockCommandHandler> _logger;

        public AddChaineBlockCommandHandler(IUnitOfWork unitOfWork,
            ILogger<AddChaineBlockCommandHandler> logger, IProviderFactory providerFactory)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _providerFactory = providerFactory;
        }
        public async Task Handle(AddChainBlockCommand command)
        {
            //1) Fetch the requested block chain from given provider
            //2) Add to database 
            //thats all

            var domainsourceprovider = Enums.EnumMapper.ToDomainSourceProvider(command.Source);

            var _blockcypherProvider = _providerFactory.ProvideFor(domainsourceprovider);
            
            string? _jsonApi = null;
             string? _blockchainName = null;

            switch (command.BlockChainType)
            {
                case AppEnumBlockChain.eth_main:
                    _jsonApi = await _blockcypherProvider.GetETHAsynch();
                    _blockchainName = "ETH.main";
                    break;
                case AppEnumBlockChain.dash_main:
                    _jsonApi = await _blockcypherProvider.GetDASHAsync();
                    _blockchainName = "DASH.main";
                    break;
                case AppEnumBlockChain.btc_main:
                    _jsonApi = await _blockcypherProvider.GetBtcMainAsync();
                    _blockchainName = "BTC.main";
                    break;
                case AppEnumBlockChain.btc_test3:
                    _jsonApi = await _blockcypherProvider.GetBtcTest3SourceAsync();
                    _blockchainName = "BTC.test3";
                    break;
                case AppEnumBlockChain.ltc_main:
                    _jsonApi = await _blockcypherProvider.GetLTCSourceAsync();
                    _blockchainName = "LTC.main";
                    break;
            }

            var _chainBlock = new Domain.Aggregates.ChainAR.BlockChain(domainsourceprovider, _blockchainName, command.CreatedAt, _jsonApi);

            await _unitOfWork.ChainRepository.AddAsynch(_chainBlock);

            _unitOfWork.Commit();

            _logger.LogInformation($"Chain block {command.BlockChainType.ToString()} from {domainsourceprovider.ToString()} has been added in database");
        }
    }


}
