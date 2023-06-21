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
    public class Userlogin1Controller : Controller
    {
        private readonly ModelContext _context;

        public Userlogin1Controller(ModelContext context)
        {
            _context = context;
        }

        // GET: Userlogin1
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Userlogin1s.Include(u => u.Customer).Include(u => u.Role);
            return View(await modelContext.ToListAsync());
        }

        // GET: Userlogin1/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userlogin1 = await _context.Userlogin1s
                .Include(u => u.Customer)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Userloginid == id);
            if (userlogin1 == null)
            {
                return NotFound();
            }

            return View(userlogin1);
        }

        // GET: Userlogin1/Create
        public IActionResult Create()
        {
            ViewData["Customerid"] = new SelectList(_context.Customer1s, "Customerid", "Fname");
            ViewData["Roleid"] = new SelectList(_context.Role1s, "Roleid", "Roleid");
            return View();
        }

        // POST: Userlogin1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Userloginid,Username,Password,Roleid,Customerid")] Userlogin1 userlogin1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userlogin1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Customerid"] = new SelectList(_context.Customer1s, "Customerid", "Fname", userlogin1.Customerid);
            ViewData["Roleid"] = new SelectList(_context.Role1s, "Roleid", "Roleid", userlogin1.Roleid);
            return View(userlogin1);
        }

        // GET: Userlogin1/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userlogin1 = await _context.Userlogin1s.FindAsync(id);
            if (userlogin1 == null)
            {
                return NotFound();
            }
            ViewData["Customerid"] = new SelectList(_context.Customer1s, "Customerid", "Fname", userlogin1.Customerid);
            ViewData["Roleid"] = new SelectList(_context.Role1s, "Roleid", "Roleid", userlogin1.Roleid);
            return View(userlogin1);
        }

        // POST: Userlogin1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Userloginid,Username,Password,Roleid,Customerid")] Userlogin1 userlogin1)
        {
            if (id != userlogin1.Userloginid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userlogin1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Userlogin1Exists(userlogin1.Userloginid))
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
            ViewData["Customerid"] = (int)userlogin1.Customerid;
            //ViewData["Roleid"] = new SelectList(_context.Role1s, "Roleid", "Roleid", userlogin1.Roleid);
            ViewData["Roleid"] = (int)userlogin1.Roleid;

            return View(userlogin1);
        }

        // GET: Userlogin1/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userlogin1 = await _context.Userlogin1s
                .Include(u => u.Customer)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Userloginid == id);
            if (userlogin1 == null)
            {
                return NotFound();
            }

            return View(userlogin1);
        }

        // POST: Userlogin1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var userlogin1 = await _context.Userlogin1s.FindAsync(id);
            _context.Userlogin1s.Remove(userlogin1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Userlogin1Exists(decimal id)
        {
            return _context.Userlogin1s.Any(e => e.Userloginid == id);
        }
    }
}
