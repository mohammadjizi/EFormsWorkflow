using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Workflow.Data.Configuration;
using Workflow.Models;

namespace Workflow.Data
{
    public class WorkflowEntities: DbContext
    {
        //public WorkflowEntities() : base("WorkflowEntities") { }

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
            modelBuilder.ApplyConfiguration(new AppConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationCustomerConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationDescriptionConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationDetailConfiguration());
            modelBuilder.ApplyConfiguration(new EquationCustomerConfiguration());
        }
    }
}
