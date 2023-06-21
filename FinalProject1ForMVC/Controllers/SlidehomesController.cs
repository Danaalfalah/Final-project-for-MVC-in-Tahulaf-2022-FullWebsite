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
    public class SlidehomesController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ModelContext _context;

        public SlidehomesController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Slidehomes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Slidehomes.ToListAsync());
        }

        // GET: Slidehomes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slidehome = await _context.Slidehomes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slidehome == null)
            {
                return NotFound();
            }

            return View(slidehome);
        }

        // GET: Slidehomes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Slidehomes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Img1,Img2,Img3,ImageFile1,ImageFile2,ImageFile3")] Slidehome slidehome)
        {
            if (ModelState.IsValid)
            {
                if (slidehome.ImageFile1 != null && slidehome.ImageFile2 !=null && slidehome.ImageFile3!=null )
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName1 = Guid.NewGuid().ToString() + "_" + slidehome.ImageFile1.FileName;
                    string fileName2 = Guid.NewGuid().ToString() + "_" + slidehome.ImageFile2.FileName;
                    string fileName3 = Guid.NewGuid().ToString() + "_" + slidehome.ImageFile3.FileName;

                    string path = Path.Combine(wwwRootPath + "/Images/", fileName1);
                    string path2 = Path.Combine(wwwRootPath + "/Images/", fileName2);
                    string path3 = Path.Combine(wwwRootPath + "/Images/", fileName3);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await slidehome.ImageFile1.CopyToAsync(fileStream);
                    }
                    using (var fileStream = new FileStream(path2, FileMode.Create))
                    {
                        await slidehome.ImageFile2.CopyToAsync(fileStream);
                    }
                    using (var fileStream = new FileStream(path3, FileMode.Create))
                    {
                        await slidehome.ImageFile3.CopyToAsync(fileStream);
                    }
                    slidehome.Img1 = fileName1;
                    slidehome.Img2 = fileName2;
                    slidehome.Img3 = fileName3;

                    _context.Add(slidehome);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                //_context.Add(slidehome);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return View(slidehome);
        }

        // GET: Slidehomes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slidehome = await _context.Slidehomes.FindAsync(id);
            if (slidehome == null)
            {
                return NotFound();
            }
            return View(slidehome);
        }

        // POST: Slidehomes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Id,Img1,Img2,Img3,ImageFile1,ImageFile2,ImageFile3")] Slidehome slidehome)
        {
            if (id != slidehome.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (slidehome.ImageFile1 != null && slidehome.ImageFile2 != null && slidehome.ImageFile3 != null)
                    {
                        string wwwRootPath = _webHostEnvironment.WebRootPath;
                        string fileName1 = Guid.NewGuid().ToString() + "_" + slidehome.ImageFile1.FileName;
                        string fileName2 = Guid.NewGuid().ToString() + "_" + slidehome.ImageFile2.FileName;
                        string fileName3 = Guid.NewGuid().ToString() + "_" + slidehome.ImageFile3.FileName;

                        string path = Path.Combine(wwwRootPath + "/Images/", fileName1);
                        string path2 = Path.Combine(wwwRootPath + "/Images/", fileName2);
                        string path3 = Path.Combine(wwwRootPath + "/Images/", fileName3);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await slidehome.ImageFile1.CopyToAsync(fileStream);
                        }
                        using (var fileStream = new FileStream(path2, FileMode.Create))
                        {
                            await slidehome.ImageFile2.CopyToAsync(fileStream);
                        }
                        using (var fileStream = new FileStream(path3, FileMode.Create))
                        {
                            await slidehome.ImageFile3.CopyToAsync(fileStream);
                        }
                        slidehome.Img1 = fileName1;
                        slidehome.Img2 = fileName2;
                        slidehome.Img3 = fileName3;

                    }
                    else 
                    {
                        var objects = _context.Slidehomes.AsNoTracking().Where(x => x.Id == slidehome.Id).FirstOrDefault();

                        slidehome.Img1 = objects.Img1;
                        slidehome.Img2 = objects.Img2;
                        slidehome.Img3 = objects.Img3;
                    }
                    //if else insted after else 

                    _context.Update(slidehome);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlidehomeExists(slidehome.Id))
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
            return View(slidehome);
        }

        // GET: Slidehomes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slidehome = await _context.Slidehomes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (slidehome == null)
            {
                return NotFound();
            }

            return View(slidehome);
        }

        // POST: Slidehomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var slidehome = await _context.Slidehomes.FindAsync(id);
            _context.Slidehomes.Remove(slidehome);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlidehomeExists(decimal id)
        {
            return _context.Slidehomes.Any(e => e.Id == id);
        }
    }
}
