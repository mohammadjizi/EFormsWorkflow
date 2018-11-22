using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Workflow.Data.Configuration;
using Workflow.Models;

namespace Workflow.Data
{
    public class WorkflowEntities: DbContext
    {
        private readonly IConfiguration _configuration;

        public WorkflowEntities(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<ApplicationCustomer> ApplicationCustomer { get; set; }
        public DbSet<EquationCustomer> EquationCustomer { get; set; }
        public DbSet<ApplicationDetail> ApplicationDetail { get; set; }
        public DbSet<ApplicationDescription> ApplicationDescription { get; set; }

        public virtual Task<int> Commit()
        {
          return  base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            //modelBuilder.ApplyConfiguration(new AppConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationCustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationDescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationDetailConfiguration());
            modelBuilder.ApplyConfiguration(new EquationCustomerConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
