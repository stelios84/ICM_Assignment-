using Application.Enums;
using Application.Helpers;
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
        IsourceProviderFactory _providerFactory;
        ILogger<AddChaineBlockCommandHandler> _logger;


        public AddChaineBlockCommandHandler(IUnitOfWork unitOfWork,
            ILogger<AddChaineBlockCommandHandler> logger, IsourceProviderFactory providerFactory)
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

            var domainsourceprovider = MappingHelper.ToDomainSourceProvider(command.Source);
            var _ProviderToFetchChains = _providerFactory.ProvideFor(domainsourceprovider);

            var _domainchainType = MappingHelper.ToDomainchainType(command.Source, command.BlockChainType);

            //get json from provider
            string _jsonApi = await _ProviderToFetchChains.GetChainBlock(_domainchainType);


            //create new chainBlock AR
            var _chainBlock = new Domain.Aggregates.ChainAR.BlockChain(domainsourceprovider, _domainchainType.Name, command.CreatedAt, _jsonApi);

            //add
            await _unitOfWork.ChainRepository.AddAsynch(_chainBlock);
            _unitOfWork.Commit();

            _logger.LogInformation($"Chain block {command.BlockChainType.ToString()} from {domainsourceprovider.ToString()} has been added in database");
        }
    }

}
