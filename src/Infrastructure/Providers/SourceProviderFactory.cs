using Domain.Providers;

namespace Infrastructure.Providers
{
    internal class SourceProviderFactory : IsourceProviderFactory
    {
        HttpClient _httpclient;
        public SourceProviderFactory(HttpClient httpClient)
        {
            _httpclient = httpClient;
        }
        public AbstractSourceProvider ProvideFor(EnumSourceProvider enumSourceProvider)
        {
            switch (enumSourceProvider)
            {
                case EnumSourceProvider.Blockcypher:
                    return new Providers.BlockCypherProvider(_httpclient);
            }
            throw new NotImplementedException();
        }
    }
}
