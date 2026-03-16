using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DB.DBContext
{
    public class AppDBContext : DbContext
    {
        
        

        public DbSet<Entities.Chain> Chains { get; set; }


        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Chain>().ToTable("Chains");
            modelBuilder.Entity<Entities.Chain>(x =>
            {
                x.HasKey(g => g.ID);

                x.HasIndex(e => e.ID);
                x.HasIndex(e => e.CreatedAt);
                x.HasIndex(e => e.Name);
                x.HasIndex(e => e.sourceProvider);


                // These properties are marked as required at the database level.
                // Technically, this is not strictly necessary because our domain model
                // already enforces validation rules, expressing what a valid Chain is.
                // Adding the constraints here ensures the database also enforces them,
                // providing an additional layer of protection and preventing invalid data
                // from being inserted outside the domain layer.
                x.Property(g=>g.Name).IsRequired();
                x.Property(g => g.CreatedAt).IsRequired();
                x.Property(g => g.sourceProvider).IsRequired();
                
                
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
