using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NETCORE_PROJECT.Areas.Identity.Data;
using ASP.NETCORE_PROJECT.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ASP.NETCORE_PROJECT.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class TypeLaptopController : Controller
    {       
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TypeLaptopController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return _context.TypeLaptop != null ?
                        View(await _context.TypeLaptop.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.TypeLaptop'  is null.");
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.TypeLaptop == null)
            {
                return NotFound();
            }

            var typeLaptop = await _context.TypeLaptop
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeLaptop == null)
            {
                return NotFound();
            }
            return View(typeLaptop);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TypeLaptop typeLaptop)
        {
            string uniqueFileName = UploadedFile(typeLaptop);
            typeLaptop.Id = Guid.NewGuid();
            typeLaptop.Image = uniqueFileName;
            _context.Add(typeLaptop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private string UploadedFile(TypeLaptop model)
        {
            string uniqueFileName = string.Empty;
            if (model.TypeLaptopImage != null)
            {
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Admin/assets/images/typelaptop");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.TypeLaptopImage.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.TypeLaptopImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.TypeLaptop == null)
            {
                return NotFound();
            }

            var typeLaptop = await _context.TypeLaptop.FindAsync(id);
            if (typeLaptop == null)
            {
                return NotFound();
            }
            return View(typeLaptop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, TypeLaptop typeLaptop)
        {
            if (id != typeLaptop.Id)
            {
                return NotFound();
            }

            else
            {
                try
                {
                    var data = await _context.TypeLaptop.FindAsync(id);
                    string uniqueFileName = string.Empty;
                    if (typeLaptop.TypeLaptopImage != null)
                    {
                        if (data.Image != null)
                        {
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Admin/assets/images/typelaptop", data.Image);
                            if (System.IO.File.Exists(filePath))
                            {
                                System.IO.File.Delete(filePath);
                            }
                        }
                        uniqueFileName = UploadedFile(typeLaptop);
                    }
                    data.Name = typeLaptop.Name;
                    if (typeLaptop.TypeLaptopImage != null)
                    {
                        data.Image = uniqueFileName;
                    }
                    _context.Update(data);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeLaptopExists(typeLaptop.Id))
                    {
                         return View(typeLaptop);
                    }
                    else
                    {
                        throw;
                    }
                   
                }
            }
        }
      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.TypeLaptop == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TypeLaptop'  is null.");
            }
            var typeLaptop = await _context.TypeLaptop.FindAsync(id);
            if (typeLaptop != null)
            {
                string deleteFromFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Admin/assets/images/typelaptop");
                string currentImage = Path.Combine(Directory.GetCurrentDirectory(), deleteFromFolder, typeLaptop.Image);
                if (currentImage != null)
                {
                    if (System.IO.File.Exists(currentImage))
                    {
                        System.IO.File.Delete(currentImage);
                    }
                }
                _context.TypeLaptop.Remove(typeLaptop);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool TypeLaptopExists(Guid id)
        {
            return (_context.TypeLaptop?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
