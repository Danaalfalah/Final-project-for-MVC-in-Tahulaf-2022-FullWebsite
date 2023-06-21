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
    public class Orderitem1Controller : Controller
    {
        private readonly ModelContext _context;

        public Orderitem1Controller(ModelContext context)
        {
            _context = context;
        }

        // GET: Orderitem1
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Orderitem1s.Include(o => o.Product);
            return View(await modelContext.ToListAsync());
        }

        // GET: Orderitem1/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderitem1 = await _context.Orderitem1s
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Orderitemid == id);
            if (orderitem1 == null)
            {
                return NotFound();
            }

            return View(orderitem1);
        }

        // GET: Orderitem1/Create
        public IActionResult Create()
        {
            ViewData["Productid"] = new SelectList(_context.Product1s, "Productid", "Productname");
            return View();
        }

        // POST: Orderitem1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Orderitemid,Quantityitem,Productid")] Orderitem1 orderitem1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderitem1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Productid"] = new SelectList(_context.Product1s, "Productid", "Productname", orderitem1.Productid);
            return View(orderitem1);
        }

        // GET: Orderitem1/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderitem1 = await _context.Orderitem1s.FindAsync(id);
            if (orderitem1 == null)
            {
                return NotFound();
            }
            ViewData["Productid"] = new SelectList(_context.Product1s, "Productid", "Productname", orderitem1.Productid);
            return View(orderitem1);
        }

        // POST: Orderitem1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Orderitemid,Quantityitem,Productid")] Orderitem1 orderitem1)
        {
            if (id != orderitem1.Orderitemid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderitem1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Orderitem1Exists(orderitem1.Orderitemid))
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
            ViewData["Productid"] = new SelectList(_context.Product1s, "Productid", "Productname", orderitem1.Productid);
            return View(orderitem1);
        }

        // GET: Orderitem1/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            var x1 = _context.Contactus.Where(x => x.Id == 1).FirstOrDefault();
            ViewBag.phone = x1.Phone;
            ViewBag.email = x1.Email;
            var phone = x1.Phone;
            var email = x1.Email;
            var location = _context.Locations.ToList();
            var loc = _context.Locations.Where(x => x.Id == 1).SingleOrDefault();
            ViewBag.loc1url = loc.Locationanurl;
            ViewBag.loc1name = loc.Locationname;
            var loc2 = _context.Locations.Where(x => x.Id == 2).SingleOrDefault();
            ViewBag.loc2url = loc2.Locationanurl;
            ViewBag.loc2name = loc2.Locationname;
            if (id == null)
            {
                return NotFound();
            }

            var orderitem1 = await _context.Orderitem1s
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Orderitemid == id);
            if (orderitem1 == null)
            {
                return NotFound();
            }

            return View(orderitem1);
        }

        // POST: Orderitem1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var orderitem1 = await _context.Orderitem1s.FindAsync(id);
            _context.Orderitem1s.Remove(orderitem1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Orderitem1Exists(decimal id)
        {
            return _context.Orderitem1s.Any(e => e.Orderitemid == id);
        }
    }
}
