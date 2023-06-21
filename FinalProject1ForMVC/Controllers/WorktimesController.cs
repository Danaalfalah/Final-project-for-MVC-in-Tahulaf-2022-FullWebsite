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
    public class WorktimesController : Controller
    {
        private readonly ModelContext _context;

        public WorktimesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Worktimes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Worktimes.ToListAsync());
        }

        // GET: Worktimes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worktime = await _context.Worktimes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (worktime == null)
            {
                return NotFound();
            }

            return View(worktime);
        }

        // GET: Worktimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Worktimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SunThursdayopen,SunThursdayclose,FriSatopen,FriSatclose")] Worktime worktime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(worktime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(worktime);
        }

        // GET: Worktimes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worktime = await _context.Worktimes.FindAsync(id);
            if (worktime == null)
            {
                return NotFound();
            }
            return View(worktime);
        }

        // POST: Worktimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,SunThursdayopen,SunThursdayclose,FriSatopen,FriSatclose")] Worktime worktime)
        {
            if (id != worktime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(worktime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorktimeExists(worktime.Id))
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
            return View(worktime);
        }

        // GET: Worktimes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var worktime = await _context.Worktimes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (worktime == null)
            {
                return NotFound();
            }

            return View(worktime);
        }

        // POST: Worktimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var worktime = await _context.Worktimes.FindAsync(id);
            _context.Worktimes.Remove(worktime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorktimeExists(decimal id)
        {
            return _context.Worktimes.Any(e => e.Id == id);
        }
    }
}
