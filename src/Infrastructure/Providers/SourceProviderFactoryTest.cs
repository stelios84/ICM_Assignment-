using Domain.Providers;

namespace Infrastructure.Providers
{
    internal class SourceProviderFactoryTest : IsourceProviderFactory
    {
        HttpClient _httpclient;
        public SourceProviderFactoryTest(HttpClient httpClient)
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
