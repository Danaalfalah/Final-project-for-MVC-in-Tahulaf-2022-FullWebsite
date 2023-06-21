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
    public class Product1Controller : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public Product1Controller(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }

        // GET: Product1
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Product1s.Include(p => p.Categoryproduct);
            return View(await modelContext.ToListAsync());
        }

        // GET: Product1/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product1 = await _context.Product1s
                .Include(p => p.Categoryproduct)
                .FirstOrDefaultAsync(m => m.Productid == id);
            if (product1 == null)
            {
                return NotFound();
            }

            return View(product1);
        }

        // GET: Product1/Create
        public IActionResult Create()
        {
            ViewData["Categoryproductid"] = new SelectList(_context.Categoryproduct1s, "Categoryproductid", "Categoryproductname");
            return View();
        }

        // POST: Product1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Productid,Productname,Sale,Price,Descriptions,Quantity,Imagepath,ImageFile,Categoryproductid")] Product1 product1)
        {
            if (ModelState.IsValid)
            {
                if (product1.ImageFile != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + product1.ImageFile.FileName;
                    string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await product1.ImageFile.CopyToAsync(fileStream);
                    }
                    product1.Imagepath = fileName;

                    _context.Add(product1);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["Categoryproductid"] = new SelectList(_context.Categoryproduct1s, "Categoryproductid", "Categoryproductname", product1.Categoryproductid);
            return View(product1);
        }

        // GET: Product1/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product1 = await _context.Product1s.FindAsync(id);
            if (product1 == null)
            {
                return NotFound();
            }
            ViewData["Categoryproductid"] = new SelectList(_context.Categoryproduct1s, "Categoryproductid", "Categoryproductname", product1.Categoryproductid);
            return View(product1);
        }

        // POST: Product1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Productid,Productname,Sale,Price,Descriptions,Quantity,Imagepath,ImageFile,Categoryproductid")] Product1 product1)
        {
            if (id != product1.Productid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (product1.ImageFile != null)

                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + product1.ImageFile.FileName;
                        string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await product1.ImageFile.CopyToAsync(fileStream);
                        }
                        product1.Imagepath = fileName;
                        //_context.Add(product1);
                        //await _context.SaveChangesAsync();
                        //return RedirectToAction(nameof(Index));
                    }

                    else
                    {
                        var objects = _context.Product1s.AsNoTracking().Where(x => x.Productid == product1.Productid).FirstOrDefault();

                        product1.Imagepath = objects.Imagepath;
                    }
                    _context.Update(product1);
                    await _context.SaveChangesAsync();
                }


                catch (DbUpdateConcurrencyException)
                {
                    if (!Product1Exists(product1.Productid))
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
            ViewData["Categoryproductid"] = new SelectList(_context.Categoryproduct1s, "Categoryproductid", "Categoryproductname", product1.Categoryproductid);
            return View(product1);
        }

        // GET: Product1/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product1 = await _context.Product1s
                .Include(p => p.Categoryproduct)
                .FirstOrDefaultAsync(m => m.Productid == id);
            if (product1 == null)
            {
                return NotFound();
            }

            return View(product1);
        }

        // POST: Product1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var product1 = await _context.Product1s.FindAsync(id);
            _context.Product1s.Remove(product1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Product1Exists(decimal id)
        {
            return _context.Product1s.Any(e => e.Productid == id);
        }
    }
}
