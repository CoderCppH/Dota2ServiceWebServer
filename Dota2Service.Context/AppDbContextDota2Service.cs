using Dota2Service.Context.Configurations;
using Dota2Service.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dota2Service.Context
{
    public class AppDbContextDota2Service : DbContext
    {
        private string NameConfigDbConnection = "PostgresSql";
        private readonly IConfiguration _configurationSection;
        public AppDbContextDota2Service(IConfiguration configurationSection) 
        {
            _configurationSection = configurationSection;
            Database.EnsureCreated();
        }
        private AppDbContextDota2Service(DbContextOptions<AppDbContextDota2Service> options): base(options) {
      
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SubscriptionConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configurationSection.GetConnectionString(NameConfigDbConnection));
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<SubscriptionModel> Subscriptions { get; set; }
    }
}
