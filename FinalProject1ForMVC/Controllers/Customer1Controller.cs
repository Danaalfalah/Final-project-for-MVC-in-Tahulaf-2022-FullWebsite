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
    public class Customer1Controller : Controller
    {
        private readonly ModelContext _context;

        public Customer1Controller(ModelContext context)
        {
            _context = context;
        }

        // GET: Customer1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer1s.ToListAsync());
        }

        // GET: Customer1/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer1 = await _context.Customer1s
                .FirstOrDefaultAsync(m => m.Customerid == id);
            if (customer1 == null)
            {
                return NotFound();
            }

            return View(customer1);
        }

        // GET: Customer1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Customerid,Fname,Lname,Phone,Address")] Customer1 customer1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer1);
        }

        // GET: Customer1/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer1 = await _context.Customer1s.FindAsync(id);
            if (customer1 == null)
            {
                return NotFound();
            }
            return View(customer1);
        }

        // POST: Customer1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Customerid,Fname,Lname,Phone,Address")] Customer1 customer1)
        {
            if (id != customer1.Customerid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Customer1Exists(customer1.Customerid))
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
            return View(customer1);
        }

        // GET: Customer1/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer1 = await _context.Customer1s
                .FirstOrDefaultAsync(m => m.Customerid == id);
            if (customer1 == null)
            {
                return NotFound();
            }

            return View(customer1);
        }

        // POST: Customer1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var customer1 = await _context.Customer1s.FindAsync(id);
            _context.Customer1s.Remove(customer1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Customer1Exists(decimal id)
        {
            return _context.Customer1s.Any(e => e.Customerid == id);
        }
    }
}
