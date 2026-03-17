using Domain.Providers;

namespace Infrastructure.Providers
{
    public class BlockCypherProvider : AbstractSourceProvider
    {
        List<EndPointItem> _registerendpoints;
        HttpClient cl;
        public BlockCypherProvider(HttpClient httpClient)
        {
            cl = httpClient;
            _registerendpoints = new List<EndPointItem>
           {
               new EndPointItem("https://api.blockcypher.com/v1/eth/main",  BlockCypherchaineType.ETH),
               new EndPointItem("https://api.blockcypher.com/v1/dash/main", BlockCypherchaineType.Dash),
               new EndPointItem("https://api.blockcypher.com/v1/btc/main", BlockCypherchaineType.Btc_Main),
               new EndPointItem("https://api.blockcypher.com/v1/btc/test3", BlockCypherchaineType.BTC_Test3),
               new EndPointItem("https://api.blockcypher.com/v1/ltc/main", BlockCypherchaineType.LTC_Main)
           };
        }

        public override EnumSourceProvider SourceProviderType => EnumSourceProvider.Blockcypher;

        public override async Task<string> GetChainBlock(ChaineType absChains, CancellationToken cancellationtoken = default)
        {
            if (absChains is BlockCypherchaineType p)
            {
                var registerendpoint = _registerendpoints.FirstOrDefault(g => g.ChainType == absChains);
                if (registerendpoint == null)
                {
                    throw new Exception("Endpoint not registered");
                }
                return await cl.GetStringAsync(registerendpoint.url, cancellationtoken);
               
            }
            throw new NotImplementedException();
        }

    }
}
