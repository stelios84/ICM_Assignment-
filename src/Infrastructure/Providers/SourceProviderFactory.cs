using Domain.Providers;

namespace Infrastructure.Providers
{
    public class SourceProviderFactory : IProviderFactory
    {
        

        public ISourceProvider ProvideFor(EnumSourceProvider enumSourceProvider)
        {
            switch (enumSourceProvider)
            {
                case EnumSourceProvider.Blockcypher:
                    return new Providers.BlockcypherProvider(new HttpClient());
            }
            
            throw new NotImplementedException();
        }

    }
}
