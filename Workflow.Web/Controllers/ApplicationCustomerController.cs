using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Workflow.Data.Infrastructure;
using Workflow.Models;
using Workflow.Service;

namespace WorkflowForms.Controllers
{
    public class ApplicationCustomerController : Controller
    {
        private readonly IEquationCustomerService _equationCustomerService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public ApplicationCustomerController(IEquationCustomerService equationCustomerService, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _equationCustomerService = equationCustomerService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //// GET: ApplicationCustomer
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.ApplicationCustomer.ToListAsync());
        //}

        //// GET: ApplicationCustomer/Details/5
        //[HttpGet]
        //public async Task<PartialViewResult> Details(string accountNumber)
        //{
        //    if (accountNumber == null)
        //    {
        //        //return NotFound();
        //    }

        //    //var applicationCustomer = await _context.ApplicationCustomer
        //    //    .FirstOrDefaultAsync(m => m.AccountNumber == accountNumber);
        //    //if (applicationCustomer == null)
        //    //{
        //    //    //return NotFound();
        //    //}

        //    //var cust = await _context.EquationCustomer.FirstOrDefaultAsync(m => m.AccountNumber == accountNumber);

        //    //var applicationCustomer = new ApplicationCustomer()
        //    //{
        //    //    AccountNumber = cust.AccountNumber,
        //    //    MobileNumber = cust.MobileNumber,
        //    //    IDNumber = cust.IDNumber,
        //    //    IDType = cust.IDType,

        //    //};

        //    return PartialView("ApplicationCustomer/Create",applicationCustomer);
        //}

        //[Authorize]
        //// GET: ApplicationCustomer/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        [Authorize]
        public async Task<IActionResult> Search(string accNumber)
        {
            var appCustomer = new ApplicationCustomer()
            {
                AccountNumber = accNumber
            };


            if (!ModelState.IsValid)
            {
                return PartialView("ApplicationCustomer/Create", appCustomer);
            }

            var cust = await _equationCustomerService.SearchCustomer(accNumber);
            if (cust == null)
            {
                return NotFound();
            }

            var appCust = _mapper.Map<ApplicationCustomer>(cust);

            return PartialView("ApplicationCustomer/Create", appCust);
        }

        //// POST: ApplicationCustomer/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,AccountNumber,IDNumber,IDType,MobileNumber,FullName")] ApplicationCustomer applicationCustomer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(applicationCustomer);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(applicationCustomer);
        //}

        //// GET: ApplicationCustomer/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var applicationCustomer = await _context.ApplicationCustomer.FindAsync(id);
        //    if (applicationCustomer == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(applicationCustomer);
        //}

        //// POST: ApplicationCustomer/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,AccountNumber,IDNumber,IDType,MobileNumber,FullName")] ApplicationCustomer applicationCustomer)
        //{
        //    if (id != applicationCustomer.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(applicationCustomer);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ApplicationCustomerExists(applicationCustomer.Id))
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
        //    return View(applicationCustomer);
        //}

        //// GET: ApplicationCustomer/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var applicationCustomer = await _context.ApplicationCustomer
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (applicationCustomer == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(applicationCustomer);
        //}

        //// POST: ApplicationCustomer/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var applicationCustomer = await _context.ApplicationCustomer.FindAsync(id);
        //    _context.ApplicationCustomer.Remove(applicationCustomer);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ApplicationCustomerExists(int id)
        //{
        //    return _context.ApplicationCustomer.Any(e => e.Id == id);
        //}
    }
}
