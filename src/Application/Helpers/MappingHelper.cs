using Application.Enums;

namespace Application.Helpers
{
    public static class MappingHelper
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

        
        public static Domain.Providers.ChaineType ToDomainchainType(AppEnumSourceProvider appEnumSourceProvider,AppEnumBlockChain chain)
        {
            if(appEnumSourceProvider== AppEnumSourceProvider.Blockcypher)
            {
                switch (chain)
                {
                    case AppEnumBlockChain.eth_main:
                        return Domain.Providers.BlockCypherchaineType.ETH;
                    case AppEnumBlockChain.dash_main:
                        return Domain.Providers.BlockCypherchaineType.Dash;
                    case AppEnumBlockChain.btc_main:
                        return Domain.Providers.BlockCypherchaineType.Btc_Main;
                    case AppEnumBlockChain.btc_test3:
                        return Domain.Providers.BlockCypherchaineType.BTC_Test3;
                    case AppEnumBlockChain.ltc_main:
                        return Domain.Providers.BlockCypherchaineType.LTC_Main;
                }

            }
            throw new ArgumentOutOfRangeException($"Could not find related chain for {chain.ToString()}");
        }

        public static string GetChainName(AppEnumSourceProvider fromprovider,AppEnumBlockChain fromchain)
        {
            string? _chainBlockName = null;
            if(fromprovider== AppEnumSourceProvider.Blockcypher)
            {
                switch (fromchain)
                {
                    case AppEnumBlockChain.eth_main:
                        _chainBlockName = "ETH.main";
                        break;
                    case AppEnumBlockChain.dash_main:
                        _chainBlockName = "DASH.main";
                        break;
                    case AppEnumBlockChain.btc_main:
                        _chainBlockName = "BTC.main";
                        break;
                    case AppEnumBlockChain.btc_test3:
                        _chainBlockName = "BTC.test3";
                        break;
                    case AppEnumBlockChain.ltc_main:
                        _chainBlockName = "LTC.main";
                        break;
                }
            }

            if (_chainBlockName == null)
            {
                throw new KeyNotFoundException($"Could not identify {fromchain.ToString()} from provider {fromprovider}");
            }

            return _chainBlockName;
        }
    }
}
