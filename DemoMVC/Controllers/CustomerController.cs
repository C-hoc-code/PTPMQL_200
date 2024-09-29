using DemoMVC.Data;
using DemoMVC.Models.Entites;
namespace DemoMVC.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

    public class CustomerController : Controller
    {
        private readonly ApplicationContext _context;

        public CustomerController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Customer cus)
        {
            if (ModelState.IsValid)
            {
                _context.Customer.Add(cus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cus);
        }


        public async Task<IActionResult> Edit(Guid? id)
        {
            var Customer = await _context.Customer.FindAsync(id);
            if (Customer == null)
            {
                return NotFound();
            }
            return View(Customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Customer cus)
        {
            if (id != cus.CustomerId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Customer.Update(cus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(cus.CustomerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cus);
        }
        public bool CustomerExists(Guid id)
        {
            return _context.Customer.Any(e => e.CustomerId == id);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var cus = await _context.Customer.FindAsync(id);
            if(cus == null)
            {
                return NotFound();
            }
            return View(cus);  
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
          public async Task<IActionResult> DeleteConfirmed(Guid id)
          {
            var cus = await _context.Customer.FindAsync(id);
            if (cus != null)
            {
                _context.Customer.Remove(cus);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
          }

           public async Task<IActionResult> Details(Guid? id)
        {
            var Customer = await _context.Customer.FindAsync(id);
            if (Customer == null)
            {
                return NotFound();
            }
            return View(Customer);
        }

    }

}