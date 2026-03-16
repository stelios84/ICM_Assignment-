using Application.AppServices;
using Application.CQRS.Commands;
using Application.CQRS.Queries;
using Application.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ICWEBAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockChainController : ControllerBase
    {
        Application.AppServices.IAppChainService _appChainService;
        ILogger<BlockChainController> _logger;
        IBlockChainQueries _blockChainQueries;
        Application.CQRS.ICommandDispatcher _CommandDispatcher;

        public BlockChainController(IAppChainService appChainService, IBlockChainQueries blockChainQueries,
            ILogger<BlockChainController> logger, Application.CQRS.ICommandDispatcher commandDispatcher)
        {
            _appChainService = appChainService;

            _blockChainQueries = blockChainQueries;
            _logger = logger;
            _CommandDispatcher = commandDispatcher;
        }


        [HttpGet("eth/main")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching chain data for {Chain}", "ETH.main");

            var cmd = new Application.CQRS.Commands.AddChainBlockCommand(AppEnumBlockChain.eth_main,
                DateTime.Now,
                AppEnumSourceProvider.Blockcypher);

            //Approach #1
            //Using dispatcher from controller
            await _CommandDispatcher.DispatchAsync(cmd, cancellationToken);

            //Or we can use Application Service
            //await _appChainService.AddChainBlock(cmd, cancellationToken);

            var history = await _blockChainQueries.GetBlockChainHistoryAsynch(AppEnumSourceProvider.Blockcypher,
                Application.Enums.AppEnumBlockChain.eth_main, cancellationToken);
            return Ok(history);
        }


        [HttpGet("dash/main")]
        public async Task<IActionResult> GetDash(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching chain data for {Chain}", "DASH.main");

            var cmd = new Application.CQRS.Commands.AddChainBlockCommand(AppEnumBlockChain.dash_main,
              DateTime.Now,
              AppEnumSourceProvider.Blockcypher);

            //Approach #2
            //Use app service
            await _appChainService.AddChainBlock(cmd, cancellationToken);

            //get history
            var history = await _blockChainQueries.GetBlockChainHistoryAsynch(AppEnumSourceProvider.Blockcypher, AppEnumBlockChain.dash_main, cancellationToken);
            return Ok(history);
        }


        [HttpGet("btc/main")]
        public async Task<IActionResult> GetBtc(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching chain data for {Chain}", "BTC.main");

            var cmd = new Application.CQRS.Commands.AddChainBlockCommand(AppEnumBlockChain.btc_main,
             DateTime.Now,
             AppEnumSourceProvider.Blockcypher);

            await _appChainService.AddChainBlock(cmd, cancellationToken);

            var history = await _blockChainQueries.GetBlockChainHistoryAsynch(AppEnumSourceProvider.Blockcypher, AppEnumBlockChain.btc_main, cancellationToken);

            return Ok(history);
        }

        [HttpGet("btc/test3")]
        public async Task<IActionResult> GetBtcTest3(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching chain data for {Chain}", "btc_test3");
            var cmd = new Application.CQRS.Commands.AddChainBlockCommand(AppEnumBlockChain.btc_test3,
             DateTime.Now,
             AppEnumSourceProvider.Blockcypher);

            await _appChainService.AddChainBlock(cmd, cancellationToken);


            var history =  await _blockChainQueries.GetBlockChainHistoryAsynch(AppEnumSourceProvider.Blockcypher, AppEnumBlockChain.btc_test3, cancellationToken);

            return Ok(history);
        }


        [HttpGet("ltc/main")]
        public async Task<IActionResult> Getltcmain(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Adding chain data for {Chain}", "LTC.main");
            var cmd = new AddChainBlockCommand(AppEnumBlockChain.ltc_main, DateTime.Now, AppEnumSourceProvider.Blockcypher);

            await _CommandDispatcher.DispatchAsync(cmd, cancellationToken);
            
            var history = await _blockChainQueries.GetBlockChainHistoryAsynch(AppEnumSourceProvider.Blockcypher, AppEnumBlockChain.ltc_main, cancellationToken);
            return Ok(history);
        }

    }
}
