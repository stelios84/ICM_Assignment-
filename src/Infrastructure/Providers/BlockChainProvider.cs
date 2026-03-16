using Domain.Providers;
using System.Net.Http.Json;

namespace Infrastructure.Providers
{
    /// <summary>
    /// 
    /// </summary>
    public class BlockChainProvider : IChainProvider
    {
        private List<string> _endpoints;
        public BlockChainProvider()
        {
            //_endpoints = new List<string>()
            //{
            //    "https://api.blockcypher.com/v1/eth/main",
            //    "https://api.blockcypher.com/v1/dash/main",
            //    "https://api.blockcypher.com/v1/btc/main",
            //    "https://api.blockcypher.com/v1/btc/test3",
            //    "https://api.blockcypher.com/v1/ltc/main"
            //};
        }

        public async Task<BtcMainSource> GetBtcMainAsync()
        {
            using(var clientd=new HttpClient())
            {
                var data =await clientd.GetFromJsonAsync<BtcMainSource>("https://api.blockcypher.com/v1/btc/main");
                return data;
            }
            
        }

        public async Task<BtcTest3Source> GetBtcTest3SourceAsync()
        {
            using (var clientd = new HttpClient())
            {
                var data = await clientd.GetFromJsonAsync<BtcTest3Source>("https://api.blockcypher.com/v1/btc/test3");
                return data;
            }
        }

        public async Task<DashSource> GetDashSourceAsync()
        {
            using (var clientd = new HttpClient())
            {
                var data = await clientd.GetFromJsonAsync<DashSource>("https://api.blockcypher.com/v1/dash/main");
                return data;
            }
        }

        public async Task<EthSource> GetEthAsynch()
        {
            using (var clientd = new HttpClient())
            {
                var data = await clientd.GetFromJsonAsync<EthSource>("https://api.blockcypher.com/v1/eth/main");
                return data;
            }
        }

        public async Task<LtcSource> GetLtcSourceAsync()
        {
            using (var clientd = new HttpClient())
            {
                var data = await clientd.GetFromJsonAsync<LtcSource>("https://api.blockcypher.com/v1/ltc/main");
                return data;
            }
        }
    }
}
