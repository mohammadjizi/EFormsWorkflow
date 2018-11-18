using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorkflowForms.Core.Models;

namespace WorkflowForms.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Account> Account { get; set; }
        public DbSet<ApplicationCustomer> ApplicationCustomer { get; set; }
        public DbSet<EquationCustomer> EquationCustomer { get; set; }
        public DbSet<ApplicationDetail> ApplicationDetail { get; set; }
        public DbSet<ApplicationDescription> ApplicationDescription { get; set; }
    }
}
