using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APPR_TASK1.Data;

namespace APPR_TASK1.Controllers
{
    public class CatergoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatergoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Catergories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Catergory.ToListAsync());
        }

        // GET: Catergories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catergory = await _context.Catergory
                .FirstOrDefaultAsync(m => m.ID == id);
            if (catergory == null)
            {
                return NotFound();
            }

            return View(catergory);
        }

        // GET: Catergories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Catergories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CatergoryName")] Catergory catergory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(catergory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(catergory);
        }

        // GET: Catergories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catergory = await _context.Catergory.FindAsync(id);
            if (catergory == null)
            {
                return NotFound();
            }
            return View(catergory);
        }

        // POST: Catergories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CatergoryName")] Catergory catergory)
        {
            if (id != catergory.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catergory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatergoryExists(catergory.ID))
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
            return View(catergory);
        }

        // GET: Catergories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var catergory = await _context.Catergory
                .FirstOrDefaultAsync(m => m.ID == id);
            if (catergory == null)
            {
                return NotFound();
            }

            return View(catergory);
        }

        // POST: Catergories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var catergory = await _context.Catergory.FindAsync(id);
            _context.Catergory.Remove(catergory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatergoryExists(int id)
        {
            return _context.Catergory.Any(e => e.ID == id);
        }
    }
}
