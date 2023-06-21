using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject1ForMVC.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace FinalProject1ForMVC.Controllers
{
    public class Categoryproduct1Controller : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        public Categoryproduct1Controller(ModelContext context,IWebHostEnvironment webHostEnvironment)
        {_webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        // GET: Categoryproduct1
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Categoryproduct1s.Include(c => c.Store);
            return View(await modelContext.ToListAsync());
        }

        // GET: Categoryproduct1/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryproduct1 = await _context.Categoryproduct1s
                .Include(c => c.Store)
                .FirstOrDefaultAsync(m => m.Categoryproductid == id);
            if (categoryproduct1 == null)
            {
                return NotFound();
            }

            return View(categoryproduct1);
        }

        // GET: Categoryproduct1/Create
        public IActionResult Create()
        {
            ViewData["Storeid"] = new SelectList(_context.Store1s, "Storeid", "Storename");
            return View();
        }

        // POST: Categoryproduct1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Categoryproductid,Categoryproductname,Imagepath,ImageFile,Descriptions,Storeid")] Categoryproduct1 categoryproduct1)
        {
            if (ModelState.IsValid)
            {
                if (categoryproduct1.ImageFile != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + categoryproduct1.ImageFile.FileName;
                    string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await categoryproduct1.ImageFile.CopyToAsync(fileStream);
                    }
                    categoryproduct1.Imagepath = fileName;
                    _context.Add(categoryproduct1);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["Storeid"] = new SelectList(_context.Store1s, "Storeid", "Storename", categoryproduct1.Storeid);
            return View(categoryproduct1);
        }

        // GET: Categoryproduct1/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryproduct1 = await _context.Categoryproduct1s.FindAsync(id);
            if (categoryproduct1 == null)
            {
                return NotFound();
            }

            ViewData["Storeid"] = new SelectList(_context.Store1s, "Storeid", "Storename", categoryproduct1.Storeid);
            return View(categoryproduct1);
        }

        // POST: Categoryproduct1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Categoryproductid,Categoryproductname,Imagepath,ImageFile,Descriptions,Storeid")] Categoryproduct1 categoryproduct1)
        {
            if (id != categoryproduct1.Categoryproductid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (categoryproduct1.ImageFile != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + categoryproduct1.ImageFile.FileName;
                        string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await categoryproduct1.ImageFile.CopyToAsync(fileStream);
                        }
                        categoryproduct1.Imagepath = fileName;
                        //_context.Add(categoryproduct1);
                        //await _context.SaveChangesAsync();
                        //return RedirectToAction(nameof(Index));
                    }

                    else { 
                        var objects = _context.Categoryproduct1s.AsNoTracking().Where(x => x.Categoryproductid == categoryproduct1.Categoryproductid).FirstOrDefault();
                        
                        categoryproduct1.Imagepath = objects.Imagepath;
                    }

                    _context.Update(categoryproduct1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Categoryproduct1Exists(categoryproduct1.Categoryproductid))
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
            ViewData["Storeid"] = new SelectList(_context.Store1s, "Storeid", "Storename", categoryproduct1.Storeid);
            return View(categoryproduct1);
        }

        // GET: Categoryproduct1/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryproduct1 = await _context.Categoryproduct1s
                .Include(c => c.Store)
                .FirstOrDefaultAsync(m => m.Categoryproductid == id);
            if (categoryproduct1 == null)
            {
                return NotFound();
            }

            return View(categoryproduct1);
        }

        // POST: Categoryproduct1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var categoryproduct1 = await _context.Categoryproduct1s.FindAsync(id);
            _context.Categoryproduct1s.Remove(categoryproduct1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Categoryproduct1Exists(decimal id)
        {
            return _context.Categoryproduct1s.Any(e => e.Categoryproductid == id);
        }
    }
}
