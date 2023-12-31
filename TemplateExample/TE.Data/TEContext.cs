using Microsoft.EntityFrameworkCore;
using TE.Data.configuration;

namespace TE.Data
{
    public class TEContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog = AGS_houssem; 
                                        Integrated Security = true");
            optionsBuilder.UseLazyLoadingProxies(true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Assuranceconfig());
            modelBuilder.ApplyConfiguration(new ExpertiseConfig());
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

    }
}