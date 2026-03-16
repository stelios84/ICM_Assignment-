 

namespace Application.Enums
{
    public static class EnumMapper
    {
        public static Domain.Providers.EnumSourceProvider ToDomainSourceProvider(AppEnumSourceProvider sourceProvider)
        {
            switch (sourceProvider)
            {
                case AppEnumSourceProvider.Blockcypher:
                    return Domain.Providers.EnumSourceProvider.Blockcypher;
            }

             throw new ArgumentOutOfRangeException($"Could not find related mapping for {sourceProvider.ToString()}");
        }

        public static Domain.Providers.EnumBlockChain ToDomainBlockChain(AppEnumBlockChain chain)
        {
            switch (chain)
            {
                case AppEnumBlockChain.eth_main:
                    return Domain.Providers.EnumBlockChain.eth_main;
                case AppEnumBlockChain.dash_main:
                    return Domain.Providers.EnumBlockChain.dash_main;
                case AppEnumBlockChain.btc_main:
                    return Domain.Providers.EnumBlockChain.btc_main;
                case AppEnumBlockChain.btc_test3:
                    return Domain.Providers.EnumBlockChain.btc_test3;
                case AppEnumBlockChain.ltc_main:
                    return Domain.Providers.EnumBlockChain.ltc_main;
            }
            throw new ArgumentOutOfRangeException($"Could not find related chain for {chain.ToString()}");

        }
    }
}
