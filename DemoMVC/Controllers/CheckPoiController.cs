using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Models.Entites;

namespace DemoMVC.Controllers
{
    public class CheckPoiController : Controller
    {
        private readonly ApplicationContext _context;

        public CheckPoiController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: CheckPoi
        public async Task<IActionResult> Index()
        {
            return View(await _context.CheckPoi.ToListAsync());
        }

        // GET: CheckPoi/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkPoi = await _context.CheckPoi
                .FirstOrDefaultAsync(m => m.PoiId == id);
            if (checkPoi == null)
            {
                return NotFound();
            }

            return View(checkPoi);
        }

        // GET: CheckPoi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CheckPoi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PoiId,NamePoi,poi")] CheckPoi checkPoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkPoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checkPoi);
        }

        // GET: CheckPoi/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkPoi = await _context.CheckPoi.FindAsync(id);
            if (checkPoi == null)
            {
                return NotFound();
            }
            return View(checkPoi);
        }

        // POST: CheckPoi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PoiId,NamePoi,poi")] CheckPoi checkPoi)
        {
            if (id != checkPoi.PoiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkPoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckPoiExists(checkPoi.PoiId))
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
            return View(checkPoi);
        }

        // GET: CheckPoi/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkPoi = await _context.CheckPoi
                .FirstOrDefaultAsync(m => m.PoiId == id);
            if (checkPoi == null)
            {
                return NotFound();
            }

            return View(checkPoi);
        }

        // POST: CheckPoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var checkPoi = await _context.CheckPoi.FindAsync(id);
            if (checkPoi != null)
            {
                _context.CheckPoi.Remove(checkPoi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckPoiExists(string id)
        {
            return _context.CheckPoi.Any(e => e.PoiId == id);
        }
    }
}
