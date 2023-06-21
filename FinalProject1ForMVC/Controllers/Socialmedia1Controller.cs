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
    public class Socialmedia1Controller : Controller
    {
        private readonly ModelContext _context;

        public Socialmedia1Controller(ModelContext context)
        {
            _context = context;
        }

        // GET: Socialmedia1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Socialmedia1s.ToListAsync());
        }

        // GET: Socialmedia1/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialmedia1 = await _context.Socialmedia1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialmedia1 == null)
            {
                return NotFound();
            }

            return View(socialmedia1);
        }

        // GET: Socialmedia1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Socialmedia1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Socialicon,Socialurl")] Socialmedia1 socialmedia1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socialmedia1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socialmedia1);
        }

        // GET: Socialmedia1/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialmedia1 = await _context.Socialmedia1s.FindAsync(id);
            if (socialmedia1 == null)
            {
                return NotFound();
            }
            return View(socialmedia1);
        }

        // POST: Socialmedia1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Socialicon,Socialurl")] Socialmedia1 socialmedia1)
        {
            if (id != socialmedia1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialmedia1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Socialmedia1Exists(socialmedia1.Id))
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
            return View(socialmedia1);
        }

        // GET: Socialmedia1/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialmedia1 = await _context.Socialmedia1s
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialmedia1 == null)
            {
                return NotFound();
            }

            return View(socialmedia1);
        }

        // POST: Socialmedia1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var socialmedia1 = await _context.Socialmedia1s.FindAsync(id);
            _context.Socialmedia1s.Remove(socialmedia1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Socialmedia1Exists(decimal id)
        {
            return _context.Socialmedia1s.Any(e => e.Id == id);
        }
    }
}
