using Assignment2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment2.Data
{
    public class MarketDbContext : DbContext
    {
        public MarketDbContext(DbContextOptions<MarketDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Brokerage> Brokerages { get; set; }

        public DbSet<Advertisement> Advertisements { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Brokerage>().ToTable("Brokerages");
           
            modelBuilder.Entity<Advertisement>().ToTable("Advertisements");
            modelBuilder.Entity<Subscription>().HasOne<Client>(client => client.Client)
                .WithMany(subscriptions => subscriptions.Subscriptions).HasForeignKey(key => key.ClientId);
            modelBuilder.Entity<Subscription>().HasOne<Brokerage>(brokerage=> brokerage.Brokerage)
                .WithMany(subscriptions => subscriptions.Subscriptions).HasForeignKey(key => key.BrokerageId);
            modelBuilder.Entity<Subscription>()
                .HasKey(c => new { c.ClientId, c.BrokerageId });


        }
    }
}
