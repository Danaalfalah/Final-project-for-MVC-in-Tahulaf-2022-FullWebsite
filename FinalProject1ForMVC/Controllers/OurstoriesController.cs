using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject1ForMVC.Models;

namespace FinalProject1ForMVC.Controllers
{
    public class OurstoriesController : Controller
    {
        private readonly ModelContext _context;

        public OurstoriesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Ourstories
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ourstories.ToListAsync());
        }

        // GET: Ourstories/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourstory = await _context.Ourstories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ourstory == null)
            {
                return NotFound();
            }

            return View(ourstory);
        }

        // GET: Ourstories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ourstories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Story")] Ourstory ourstory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ourstory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ourstory);
        }

        // GET: Ourstories/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourstory = await _context.Ourstories.FindAsync(id);
            if (ourstory == null)
            {
                return NotFound();
            }
            return View(ourstory);
        }

        // POST: Ourstories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Story")] Ourstory ourstory)
        {
            if (id != ourstory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ourstory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OurstoryExists(ourstory.Id))
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
            return View(ourstory);
        }

        // GET: Ourstories/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ourstory = await _context.Ourstories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ourstory == null)
            {
                return NotFound();
            }

            return View(ourstory);
        }

        // POST: Ourstories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var ourstory = await _context.Ourstories.FindAsync(id);
            _context.Ourstories.Remove(ourstory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OurstoryExists(decimal id)
        {
            return _context.Ourstories.Any(e => e.Id == id);
        }
    }
}
