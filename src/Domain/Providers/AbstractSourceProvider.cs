using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Providers
{


    public class EndPointItem
    {
        public EndPointItem(string url, ChaineType name)
        {
            this.url = url;
            ChainType = name;
        }

        public string url { get; set; }

        public ChaineType ChainType { get; set; }
    }

    public abstract class AbstractSourceProvider
    {
        public abstract EnumSourceProvider SourceProviderType { get; }
        public abstract Task<string> GetChainBlock(ChaineType chainType, CancellationToken cancellationToken = default);

    }

    public interface IsourceProviderFactory
    {
        AbstractSourceProvider ProvideFor(EnumSourceProvider enumSourceProvider);
    }

    public abstract class ChaineType
    {
        public string Name { get; }

        protected ChaineType(string name)
        {
            Name = name;
        }

       // public override string ToString() => Name;
    }

    public class BlockCypherchaineType : ChaineType
    {
        public BlockCypherchaineType(string name) : base(name)
        {
        }

        public static ChaineType Btc_Main { get; set; } = new BlockCypherchaineType("BTC.main");
        public static ChaineType LTC_Main { get; set; } = new BlockCypherchaineType("LTC.main");
        public static ChaineType ETH { get; set; } = new BlockCypherchaineType("ETH.main");
        public static ChaineType BTC_Test3 { get; set; } = new BlockCypherchaineType("BTC.test3");
        public static ChaineType Dash { get; set; } = new BlockCypherchaineType("DASH.main");
    }


    //Other chains can be set here for different provider
    [Obsolete("for demostration purposes",true)]
    public class ChainForProvider2Type : ChaineType
    {
        public ChainForProvider2Type(string name) : base(name)
        {
        }

        public static ChaineType chain_example1 { get; set; } = new BlockCypherchaineType("chain1");
        public static ChaineType chain_example2 { get; set; } = new BlockCypherchaineType("chain2");
        public static ChaineType chain_example3 { get; set; } = new BlockCypherchaineType("chain3");
    }
}
