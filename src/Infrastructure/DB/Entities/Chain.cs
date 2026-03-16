

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DB.Entities
{
    public class Chain
    {
        public int ID { get; set; }

        /// <summary>
        /// Blockcypher sources
        /// </summary>
        public string sourceProvider { get; set; }
        public string Name { get; set; }    
        public string JsonApi { get; set; }
        public string CreatedAt { get; set; }
    }
}
