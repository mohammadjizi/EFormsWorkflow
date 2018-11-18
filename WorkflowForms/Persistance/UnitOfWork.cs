using System.Threading.Tasks;
using WorkflowForms.Core;
using WorkflowForms.Core.Repositories;
using WorkflowForms.Data;
using WorkflowForms.Persistance.Repositories;

namespace WorkflowForms.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context { get; }
        public IEquationCustomerRepository Customers { get; set; }
        public IApplicationDescriptionRepository AppsDescription { get; set; }
        public IAccountRepository Accounts { get; set; }
        public  IApplicationDetailRepository AppsDetail { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Customers = new EquationCustomerRepository(context);
            AppsDescription = new ApplicationDescriptionRepository(context);
            Accounts = new AccountRepository(context);
            AppsDetail=new ApplicationDetailRepository(context);
        }

        public Task<int> Complete()
        {
          return  _context.SaveChangesAsync();
        }

        
    }
}
