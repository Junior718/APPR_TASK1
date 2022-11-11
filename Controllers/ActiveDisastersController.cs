using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APPR_TASK1.Data;
using APPR_TASK1.Models;

namespace APPR_TASK1.Controllers
{
    public class ActiveDisastersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActiveDisastersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ActiveDisasters
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActiveDisaster.ToListAsync());
        }

        // GET: ActiveDisasters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activeDisaster = await _context.ActiveDisaster
                .FirstOrDefaultAsync(m => m.id == id);
            if (activeDisaster == null)
            {
                return NotFound();
            }

            return View(activeDisaster);
        }

        // GET: ActiveDisasters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ActiveDisasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,DisasterType")] ActiveDisaster activeDisaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activeDisaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activeDisaster);
        }

        // GET: ActiveDisasters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activeDisaster = await _context.ActiveDisaster.FindAsync(id);
            if (activeDisaster == null)
            {
                return NotFound();
            }
            return View(activeDisaster);
        }

        // POST: ActiveDisasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DisasterType")] ActiveDisaster activeDisaster)
        {
            if (id != activeDisaster.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activeDisaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActiveDisasterExists(activeDisaster.id))
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
            return View(activeDisaster);
        }

        // GET: ActiveDisasters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activeDisaster = await _context.ActiveDisaster
                .FirstOrDefaultAsync(m => m.id == id);
            if (activeDisaster == null)
            {
                return NotFound();
            }

            return View(activeDisaster);
        }

        // POST: ActiveDisasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activeDisaster = await _context.ActiveDisaster.FindAsync(id);
            _context.ActiveDisaster.Remove(activeDisaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActiveDisasterExists(int id)
        {
            return _context.ActiveDisaster.Any(e => e.id == id);
        }
    }
}
