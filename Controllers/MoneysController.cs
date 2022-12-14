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
    public class MoneysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoneysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Moneys
        public async Task<IActionResult> Index()
        {
            return View(await _context.Money.ToListAsync());
        }

        // GET: Moneys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var money = await _context.Money
                .FirstOrDefaultAsync(m => m.ID == id);
            if (money == null)
            {
                return NotFound();
            }

            return View(money);
        }

        // GET: Moneys/Create
        public IActionResult Create()
        {
            List<Disaster> disaster = new List<Disaster>();
            disaster = _context.Disaster.ToList();
            ViewBag.types = disaster;
            return View();
        }

        // POST: Moneys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Amount,Date,Type")] Money money)
        {
            if (ModelState.IsValid)
            {
                _context.Add(money);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(money);
        }

        // GET: Moneys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var money = await _context.Money.FindAsync(id);
            if (money == null)
            {
                return NotFound();
            }
            return View(money);
        }

        // POST: Moneys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Amount,Date,Type")] Money money)
        {
            if (id != money.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(money);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoneyExists(money.ID))
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
            return View(money);
        }

        // GET: Moneys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var money = await _context.Money
                .FirstOrDefaultAsync(m => m.ID == id);
            if (money == null)
            {
                return NotFound();
            }

            return View(money);
        }

        // POST: Moneys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var money = await _context.Money.FindAsync(id);
            _context.Money.Remove(money);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoneyExists(int id)
        {
            return _context.Money.Any(e => e.ID == id);
        }
    }
}
