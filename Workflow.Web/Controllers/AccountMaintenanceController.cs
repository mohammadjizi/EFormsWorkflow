using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Workflow.Data.Infrastructure;
using Workflow.Models;
using Workflow.Service;
using Workflow.Web.ViewModels;

namespace WorkflowForms.Controllers
{
    public class AccountMaintenanceController : Controller
    {
        private readonly IAccountService _accountService;

        private readonly IMapper _mapper;

        private readonly IApplicationDescriptionService _applicationDescriptionService;

        private readonly IApplicationDetailService _applicationDetailService;

        private readonly IEquationCustomerService _equationCustomerService;

        private readonly IUnitOfWork _unitOfWork;

        public AccountMaintenanceController(IAccountService accountService,
            IApplicationDescriptionService applicationDescriptionService,
            IApplicationDetailService applicationDetailService,
            IEquationCustomerService equationCustomerService, 
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _accountService = accountService;
            _applicationDescriptionService = applicationDescriptionService;
            _applicationDetailService = applicationDetailService;
            _equationCustomerService = equationCustomerService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }



        //// GET: Accounts
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Accounts.ToListAsync());
        //}

        //// GET: Accounts/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var accountMaintenance = await _context.Accounts
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (accountMaintenance == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(accountMaintenance);
        //}

        [Authorize]
        // GET: AccountMaintenance/Create
        public IActionResult Create()
        {       
            var accMaintenance = new AccountMaintenanceViewModel()
            {
                    AppType =  _applicationDescriptionService.GetAppDescription("ACM").Result.AppType,              
                    DateCreated = DateTime.Now,
                    RequestedBy = "PQA4259"
                
            };
            return View(accMaintenance);
        }

        // POST: AccountMaintenance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("AppType,DateCreated,RequestedBy,CustomerAccount,CustomerAddress,CustomerType")]
            AccountMaintenanceViewModel accountMaintenance)
        {
            if (ModelState.IsValid)
            {
                var account = _mapper.Map<Account>(accountMaintenance);
                account.AppDetail = new ApplicationDetail()
                {
                    AppDescription = await _applicationDescriptionService.GetAppDescription("ACM"),
                    DateCreated = DateTime.Now,
                    RequestedBy = "PQA4259",
                    AppNumber = "ACM" + _applicationDetailService.GetAppNumber()
                };
                var cust = await _equationCustomerService.SearchCustomer(accountMaintenance.CustomerAccount);
                account.AppCustomer = _mapper.Map<ApplicationCustomer>(cust);

                _accountService.CreateAccount(account);
                await _unitOfWork.Commit();

                //WorkflowGenerator wfGenerator= new WorkflowGenerator();
                //wfGenerator.CreateAccountMaintenance(new Version(1, 0, 0, 0));

                return RedirectToAction("Index", "Home");
            }

            return View(accountMaintenance);
        }

        //// GET: Accounts/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var accountMaintenance = await _context.Accounts.FindAsync(id);
        //    if (accountMaintenance == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(accountMaintenance);
        //}

        //// POST: Accounts/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Address,CustomerType")] Accounts accountMaintenance)
        //{
        //    if (id != accountMaintenance.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(accountMaintenance);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!AccountMaintenanceExists(accountMaintenance.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(accountMaintenance);
        //}

        //// GET: Accounts/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var accountMaintenance = await _context.Accounts
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (accountMaintenance == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(accountMaintenance);
        //}

        //// POST: Accounts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var accountMaintenance = await _context.Accounts.FindAsync(id);
        //    _context.Accounts.Remove(accountMaintenance);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool AccountMaintenanceExists(int id)
        //{
        //    return _context.Accounts.Any(e => e.Id == id);
        //}
    }
}
