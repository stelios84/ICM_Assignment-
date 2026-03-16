 

namespace Infrastructure.DB.Entities
{
    public class Dash:IEntity
    {
        public int Id { get; set; }
        public string name { get; set; } = null!;
        public int height { get; set; }
        public string hash { get; set; } = null!;
        public string time { get; set; }
        public string latest_url { get; set; } = null!;
        public string? previous_hash { get; set; }
        public string? previous_url { get; set; }
        public int? peer_count { get; set; }
        public int? unconfirmed_count { get; set; }
        public int? high_fee_per_kb { get; set; }
        public int? medium_fee_per_kb { get; set; }
        public int? low_fee_per_kb { get; set; }
        public int? last_fork_height { get; set; }
        public string? last_fork_hash { get; set; }
        public string CreatedAt { get; set; }
        public string JsonApi { get; set; }

    }
}
