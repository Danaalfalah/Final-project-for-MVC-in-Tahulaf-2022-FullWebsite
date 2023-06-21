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
    public class Categorystore1Controller : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Categorystore1Controller(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }


        // GET: Categorystore1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorystore1s.ToListAsync());
        }

        // GET: Categorystore1/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorystore1 = await _context.Categorystore1s
                .FirstOrDefaultAsync(m => m.Categoryid == id);
            if (categorystore1 == null)
            {
                return NotFound();
            }

            return View(categorystore1);
        }

        // GET: Categorystore1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorystore1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Categoryid,Categoryname,Imagepath,ImageFile,Discription")] Categorystore1 categorystore1)
        {
            if (ModelState.IsValid)
            {
                if (categorystore1.ImageFile != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + categorystore1.ImageFile.FileName;
                    string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await categorystore1.ImageFile.CopyToAsync(fileStream);
                    }
                    categorystore1.Imagepath = fileName;
                    _context.Add(categorystore1);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(categorystore1);
        }

        // GET: Categorystore1/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorystore1 = await _context.Categorystore1s.FindAsync(id);
            if (categorystore1 == null)
            {
                return NotFound();
            }
            return View(categorystore1);
        }

        // POST: Categorystore1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Categoryid,Categoryname,Imagepath,ImageFile,Discription")] Categorystore1 categorystore1)
        {
            if (id != categorystore1.Categoryid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (categorystore1.ImageFile != null)

                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + categorystore1.ImageFile.FileName;
                        string path = Path.Combine(wwwRootPath + "/Images/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await categorystore1.ImageFile.CopyToAsync(fileStream);
                        }
                        categorystore1.Imagepath = fileName;
                        //_context.Add(categorystore1);
                        //await _context.SaveChangesAsync();
                        //return RedirectToAction(nameof(Index));
                    }

                    else
                    {
                        var objects = _context.Categorystore1s.AsNoTracking().Where(x => x.Categoryid == categorystore1.Categoryid).FirstOrDefault();

                        categorystore1.Imagepath = objects.Imagepath;
                    }


                    _context.Update(categorystore1);
                    await _context.SaveChangesAsync();
                }


                catch (DbUpdateConcurrencyException)
                {
                    if (!Categorystore1Exists(categorystore1.Categoryid))
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
         
            return View(categorystore1);
        }

        // GET: Categorystore1/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorystore1 = await _context.Categorystore1s
                .FirstOrDefaultAsync(m => m.Categoryid == id);
            if (categorystore1 == null)
            {
                return NotFound();
            }

            return View(categorystore1);
        }

        // POST: Categorystore1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var categorystore1 = await _context.Categorystore1s.FindAsync(id);
            _context.Categorystore1s.Remove(categorystore1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Categorystore1Exists(decimal id)
        {
            return _context.Categorystore1s.Any(e => e.Categoryid == id);
        }
    }
}
