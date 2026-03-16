using Application.AppServices;
using Application.CQRS.Queries;
using Microsoft.AspNetCore.Mvc;

namespace ICWEBAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class BlockChainController_Old : ControllerBase
    {
        Application.AppServices.IAppChainServiceDepreciate _appChainService;
        ILogger<BlockChainController_Old> _logger;
        IBlockChainQueries _blockChainQueries;

        public BlockChainController_Old(IAppChainServiceDepreciate appChainService, ILogger<BlockChainController_Old> logger)
        {
            _appChainService = appChainService;
            _logger = logger;
        }

        [HttpGet("eth/main")]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Fetching chain data for {Chain}", "ETH.main");
            var data = await _appChainService.GetEthAsynch(); 
            
            return Ok(data);
        }

        [HttpGet("dash/main")]
        public async Task<IActionResult> GetDash()
        {
            _logger.LogInformation("Fetching chain data for {Chain}", "DASH.main");
            var data = await _appChainService.GetDashAsynch(); 
            return Ok(data);
        }

        [HttpGet("btc/main")]
        public async Task<IActionResult> GetBtc()
        {
            _logger.LogInformation("Fetching chain data for {Chain}", "BTC.main");
            var data = await _appChainService.GetBTCAsynch(); 
            return Ok(data);
        }

        [HttpGet("btc/test3")]
        public async Task<IActionResult> GetBtcTest3()
        {
            _logger.LogInformation("Fetching chain data for {Chain}", "btc_test3");

            var data = await _appChainService.GetBtcTest3Asynch();
            return Ok(data);
        }

        [HttpGet("ltc/main")]
        public async Task<IActionResult> Getltcmain()
        {
            _logger.LogInformation("Fetching chain data for {Chain}", "LTC.main");

            var data = await _appChainService.GetLtcAsynch();
            return Ok(data);
        }
    }
}
