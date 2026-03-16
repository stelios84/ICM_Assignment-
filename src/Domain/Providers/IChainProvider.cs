using System.Threading.Tasks;

namespace Domain.Providers
{
    public interface IChainProvider
    {
        
        Task<BtcMainSource> GetBtcMainAsync();

        Task<EthSource> GetEthAsynch();

        Task<DashSource> GetDashSourceAsync();

        Task<LtcSource> GetLtcSourceAsync();

        Task<BtcTest3Source> GetBtcTest3SourceAsync();



    }
    public class BtcMainSource
    {
        public string name { get; set; }

        public int height { get; set; }

        public string hash { get; set; }

        public string time { get; set; }

        public string latest_url { get; set; }

        public string previous_hash { get; set; }

        public string previous_url { get; set; }

        public int peer_count { get; set; }

        public int unconfirmed_count { get; set; }

        public int high_fee_per_kb { get; set; }

        public int medium_fee_per_kb { get; set; }

        public int low_fee_per_kb { get; set; }

        public int last_fork_height { get; set; }

        public string last_fork_hash { get; set; }
    }

    public class EthSource
    {
        public string name { get; set; }

        public int height { get; set; }

        public string hash { get; set; }

        public string time { get; set; }

        public string latest_url { get; set; }

        public string previous_hash { get; set; }

        public string previous_url { get; set; }

        public int peer_count { get; set; }

        public int unconfirmed_count { get; set; }

        public long high_gas_price { get; set; }

        public long medium_gas_price { get; set; }

        public long low_gas_price { get; set; }

        public long high_priority_fee { get; set; }

        public long medium_priority_fee { get; set; }

        public long low_priority_fee { get; set; }

        public long base_fee { get; set; }

        public int last_fork_height { get; set; }

        public string last_fork_hash { get; set; }
    }

    public class DashSource
    {
        public string name { get; set; }

        public int height { get; set; }

        public string hash { get; set; }

        public string time { get; set; }

        public string latest_url { get; set; }

        public string previous_hash { get; set; }

        public string previous_url { get; set; }

        public int peer_count { get; set; }

        public int unconfirmed_count { get; set; }

        public int high_fee_per_kb { get; set; }

        public int medium_fee_per_kb { get; set; }

        public int low_fee_per_kb { get; set; }

        public int last_fork_height { get; set; }

        public string last_fork_hash { get; set; }
    }

    public class BtcTest3Source
    {
        public string name { get; set; }

        public int height { get; set; }

        public string hash { get; set; }

        public string time { get; set; }

        public string latest_url { get; set; }

        public string previous_hash { get; set; }

        public string previous_url { get; set; }

        public int peer_count { get; set; }

        public int unconfirmed_count { get; set; }

        public int high_fee_per_kb { get; set; }

        public int medium_fee_per_kb { get; set; }

        public int low_fee_per_kb { get; set; }

        public int last_fork_height { get; set; }

        public string last_fork_hash { get; set; }
    }

    public class LtcSource
    {
        public string name { get; set; }

        public int height { get; set; }

        public string hash { get; set; }

        public string time { get; set; }

        public string latest_url { get; set; }

        public string previous_hash { get; set; }

        public string previous_url { get; set; }

        public int peer_count { get; set; }

        public int unconfirmed_count { get; set; }

        public int high_fee_per_kb { get; set; }

        public int medium_fee_per_kb { get; set; }

        public int low_fee_per_kb { get; set; }

        public int last_fork_height { get; set; }

        public string last_fork_hash { get; set; }
    }
}
