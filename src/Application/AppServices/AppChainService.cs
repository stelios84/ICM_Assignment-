using Application.CQRS.Commands;
using Application.DTO;
using Application.Enums;

namespace Application.AppServices
{
    public class AppChainService : IAppChainService
    {
        CQRS.ICommandDispatcher _commandDispatcher;
        CQRS.Queries.IBlockChainQueries _queries;
        public AppChainService(CQRS.ICommandDispatcher commandDispatcher, CQRS.Queries.IBlockChainQueries blockChainQueries)
        {
            _commandDispatcher=commandDispatcher;
            _queries=blockChainQueries;
        }

        public async Task<List<BlockChainDto>> AddAndFetch(AddChainBlockCommand addChainBlockCommand,CancellationToken cancellationtoken)
        {
            await _commandDispatcher.DispatchAsync(addChainBlockCommand,cancellationtoken);
            string BlockType="ETH.main";

            switch (addChainBlockCommand.BlockChainType)
            {
                case AppEnumBlockChain.eth_main:
                    BlockType = "ETH.main";
                    break;
                case AppEnumBlockChain.dash_main:
                    BlockType = "DASH.main";
                    break;
                case AppEnumBlockChain.btc_main:
                    BlockType = "BTC.main";
                    break;
                case AppEnumBlockChain.btc_test3:
                    BlockType = "BTC.test3";
                    break;
                case AppEnumBlockChain.ltc_main:
                    BlockType = "LTC.main";
                    break;
            }
            var history = await _queries.GetBlockChainHistoryAsynch(addChainBlockCommand.Source, addChainBlockCommand.BlockChainType, cancellationtoken);
            
            return history;
        }

        public async Task AddChainBlock(AddChainBlockCommand addChainBlockCommand,CancellationToken cancellationToken)
        {
            await _commandDispatcher.DispatchAsync(addChainBlockCommand,cancellationToken);
        }
    }
}
