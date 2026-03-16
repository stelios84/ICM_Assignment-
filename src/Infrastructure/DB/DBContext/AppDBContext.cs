using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DB.DBContext
{
    public class AppDBContext : DbContext
    {
        
        public DbSet<Entities.Eth> EthChain { get; set; }

        public DbSet<Entities.BTC> BtcChain { get; set; }

        public DbSet<Entities.BTCTest3> BtcChainTest3 { get; set; }

        public DbSet<Entities.Dash> Dash { get; set; }
        public DbSet<Entities.LTC> LtcChain { get; set; }

        public DbSet<Entities.Chain> Chains { get; set; }


        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Entities.ChainStatus>().ToTable("blockchainSypher");
            modelBuilder.Entity<Entities.BTC>().ToTable("BS_chain_BTC");
            modelBuilder.Entity<Entities.BTCTest3>().ToTable("BS_chain_BTCTEST3");
            modelBuilder.Entity<Entities.Dash>().ToTable("BS_chain_DASH");
            modelBuilder.Entity<Entities.Eth>().ToTable("BS_chain_ETH");
            modelBuilder.Entity<Entities.LTC>().ToTable("BS_chain_LTC");
            modelBuilder.Entity<Entities.Chain>().ToTable("Chains");

            base.OnModelCreating(modelBuilder);
        }
    }
}
