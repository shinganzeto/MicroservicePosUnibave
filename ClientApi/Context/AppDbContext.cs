using ClientApi.Models;
using Microsoft.EntityFrameworkCore;


namespace ClientApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }

        // Recrever modo created do migration.
        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Client>().ToTable("client");

            mb.Entity<Client>().HasKey(c => c.Id);

            mb.Entity<Client>().Property(c => c.Id).
                HasColumnName("id");

            mb.Entity<Client>().
                Property(c => c.Name).
                    HasColumnName("name").
                        HasMaxLength(255).
                            IsRequired();

            mb.Entity<Client>().
                Property(c => c.Address).
                    HasColumnName("address").
                        HasMaxLength(255).
                            IsRequired();

            mb.Entity<Client>().
                Property(c => c.Fone).
                    HasColumnName("fone").
                        HasMaxLength(30);

            mb.Entity<Client>().HasData(new Client
            {
                Id = 1,
                Name = "Robertinho",
                Address = "Pedro Alves - 502 - Sao Paulo - SP",
                Fone = "9999999"
            });
        }
    }
}
