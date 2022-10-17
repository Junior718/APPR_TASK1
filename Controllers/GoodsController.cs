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
    public class GoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Goods
        public async Task<IActionResult> Index()
        {
            return View(await _context.Goods.ToListAsync());
        }

        // GET: Goods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goods = await _context.Goods
                .FirstOrDefaultAsync(m => m.ID == id);
            if (goods == null)
            {
                return NotFound();
            }

            return View(goods);
        }

        // GET: Goods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Quantity,Date")] Goods goods)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goods);
        }

        // GET: Goods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goods = await _context.Goods.FindAsync(id);
            if (goods == null)
            {
                return NotFound();
            }
            return View(goods);
        }

        // POST: Goods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Quantity,Date")] Goods goods)
        {
            if (id != goods.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goods);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodsExists(goods.ID))
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
            return View(goods);
        }

        // GET: Goods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goods = await _context.Goods
                .FirstOrDefaultAsync(m => m.ID == id);
            if (goods == null)
            {
                return NotFound();
            }

            return View(goods);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goods = await _context.Goods.FindAsync(id);
            _context.Goods.Remove(goods);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodsExists(int id)
        {
            return _context.Goods.Any(e => e.ID == id);
        }
    }
}
