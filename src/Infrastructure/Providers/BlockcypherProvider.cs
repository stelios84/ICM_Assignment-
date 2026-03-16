
namespace Infrastructure.Providers
{
    public class BlockcypherProvider : Domain.Providers.ISourceProvider
    {
        private HttpClient cl;
        public BlockcypherProvider(HttpClient httpClient)
        {
            cl = httpClient;
        }

        public async Task<string> GetBtcMainAsync(CancellationToken cancellationToken=default)
        {

            return await cl.GetStringAsync("https://api.blockcypher.com/v1/btc/main", cancellationToken);

        }

        public async Task<string> GetBtcTest3SourceAsync(CancellationToken cancellationToken=default)
        {

            return await cl.GetStringAsync("https://api.blockcypher.com/v1/btc/test3", cancellationToken);


        }

        public async Task<string> GetDASHAsync(CancellationToken cancellationToken=default)
        {

            return await cl.GetStringAsync("https://api.blockcypher.com/v1/dash/main", cancellationToken);

        }

        public async Task<string> GetETHAsynch(CancellationToken cancellationToken = default)
        {

            return await cl.GetStringAsync("https://api.blockcypher.com/v1/eth/main", cancellationToken);

        }

        public async Task<string> GetLTCSourceAsync(CancellationToken cancellationToken = default)
        {

            return await cl.GetStringAsync("https://api.blockcypher.com/v1/ltc/main", cancellationToken);

        }
    }
}
