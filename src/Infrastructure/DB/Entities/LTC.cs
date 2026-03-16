 

namespace Infrastructure.DB.Entities
{
    public class LTC:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Height { get; set; }
        public string Hash { get; set; } = null!;
        public string Time { get; set; }
        public string Latest_Url { get; set; } = null!;
        public string? Previous_Hash { get; set; }
        public string? Previous_Url { get; set; }
        public int? Peer_Count { get; set; }
        public int? Unconfirmed_Count { get; set; }
        public int? High_Fee_Per_Kb { get; set; }
        public int? Medium_Fee_Per_Kb { get; set; }
        public int? Low_Fee_Per_Kb { get; set; }
        public int? Last_Fork_Height { get; set; }
        public string? Last_Fork_Hash { get; set; }
        public string CreatedAt { get; set; }
        public string JsonApi { get; set; }

    }
}
