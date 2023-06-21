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
    public class DeliveryinfoesController : Controller
    {
        private readonly ModelContext _context;

        public DeliveryinfoesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Deliveryinfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Deliveryinfos.ToListAsync());
        }

        // GET: Deliveryinfoes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryinfo = await _context.Deliveryinfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deliveryinfo == null)
            {
                return NotFound();
            }

            return View(deliveryinfo);
        }

        // GET: Deliveryinfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deliveryinfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Deliverycharge,Deliveryfreeabove,Numberofdaydelivery")] Deliveryinfo deliveryinfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryinfo);
        }

        // GET: Deliveryinfoes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryinfo = await _context.Deliveryinfos.FindAsync(id);
            if (deliveryinfo == null)
            {
                return NotFound();
            }
            return View(deliveryinfo);
        }

        // POST: Deliveryinfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Deliverycharge,Deliveryfreeabove,Numberofdaydelivery")] Deliveryinfo deliveryinfo)
        {
            if (id != deliveryinfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryinfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryinfoExists(deliveryinfo.Id))
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
            return View(deliveryinfo);
        }

        // GET: Deliveryinfoes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryinfo = await _context.Deliveryinfos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deliveryinfo == null)
            {
                return NotFound();
            }

            return View(deliveryinfo);
        }

        // POST: Deliveryinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var deliveryinfo = await _context.Deliveryinfos.FindAsync(id);
            _context.Deliveryinfos.Remove(deliveryinfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryinfoExists(decimal id)
        {
            return _context.Deliveryinfos.Any(e => e.Id == id);
        }
    }
}
