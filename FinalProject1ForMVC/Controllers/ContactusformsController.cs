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
    public class ContactusformsController : Controller
    {
        private readonly ModelContext _context;

        public ContactusformsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Contactusforms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contactusforms.ToListAsync());
        }

        // GET: Contactusforms/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactusform = await _context.Contactusforms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactusform == null)
            {
                return NotFound();
            }

            return View(contactusform);
        }

        // GET: Contactusforms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contactusforms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fname,Lname,Email,Phone,Message")] Contactusform contactusform)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactusform);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contactusform);
        }

        // GET: Contactusforms/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactusform = await _context.Contactusforms.FindAsync(id);
            if (contactusform == null)
            {
                return NotFound();
            }
            return View(contactusform);
        }

        // POST: Contactusforms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Fname,Lname,Email,Phone,Message")] Contactusform contactusform)
        {
            if (id != contactusform.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactusform);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactusformExists(contactusform.Id))
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
            return View(contactusform);
        }

        // GET: Contactusforms/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactusform = await _context.Contactusforms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactusform == null)
            {
                return NotFound();
            }

            return View(contactusform);
        }

        // POST: Contactusforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var contactusform = await _context.Contactusforms.FindAsync(id);
            _context.Contactusforms.Remove(contactusform);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactusformExists(decimal id)
        {
            return _context.Contactusforms.Any(e => e.Id == id);
        }
    }
}
