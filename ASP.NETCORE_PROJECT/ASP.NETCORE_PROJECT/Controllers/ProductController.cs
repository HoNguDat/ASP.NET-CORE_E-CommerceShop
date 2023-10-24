using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NETCORE_PROJECT.Areas.Identity.Data;
using ASP.NETCORE_PROJECT.Models;
using System.Drawing.Drawing2D;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ASP.NETCORE_PROJECT.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> ListProductPhone()
        {
            var applicationDbContext = _context.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.TypeLaptop);

            return View(await applicationDbContext.Where(x => x.Category.Name == "Điện thoại").ToListAsync());

        }

        public async Task<IActionResult> ListProductLaptop()
        {
            var applicationDbContext = _context.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.TypeLaptop);

            return View(await applicationDbContext.Where(x => x.Category.Name == "Laptop").ToListAsync());

        }

        public IActionResult CreateProductPhone()
        {
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductPhone(Product product)
        {
            try
            {
                string uniqueFileName = UploadedFile(product);
                product.Id = Guid.NewGuid();
                product.Image = uniqueFileName;
                _context.Add(product);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Create successful product !";
                return RedirectToAction(nameof(ListProductPhone));
            }

            catch (Exception)
            {
                ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name", product.BrandId);
                ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", product.CategoryId);
                ViewData["TypeId"] = new SelectList(_context.TypeLaptop, "Id", "Name", product.TypeId);
                return View(product);
            }
        }

        public async Task<IActionResult> EditPhoneProducts(Guid? id)
        {
            if (id == null || _context.Product == null)
            {
                return View("/Views/Shared/ErrorAdmin.cshtml");
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return View("/Views/Shared/ErrorAdmin.cshtml");
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", product.CategoryId);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPhoneProducts(Guid id, Product product)
        {
            if (id != product.Id)
            {
                return View("/Views/Shared/ErrorAdmin.cshtml");
            }
            else
            {
                try
                {
                    var data = await _context.Product.FindAsync(id);
                    string uniqueFileName = string.Empty;
                    if (product.ProductImage != null)
                    {
                        if (data.Image != null)
                        {
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Admin/assets/images/product", data.Image);
                            if (System.IO.File.Exists(filePath))
                            {
                                System.IO.File.Delete(filePath);
                            }
                        }
                        uniqueFileName = UploadedFile(product);
                    }
                    data.Name = product.Name;
                    data.Cpu = product.Cpu;
                    data.FrontCamera = product.FrontCamera;
                    data.BackCamera = product.BackCamera;
                    data.Sim = product.Sim;
                    data.Ram = product.Ram;
                    data.Storage = product.Storage;
                    data.OperatingSystem = product.OperatingSystem;
                    data.Feature = product.Feature;
                    data.Origin = product.Origin;
                    data.SizeVolume = product.SizeVolume;
                    data.Battery = product.Battery;
                    data.Quantity = product.Quantity;
                    data.YearOfManufacturer = product.YearOfManufacturer;
                    data.Price = product.Price;
                    data.Description = product.Description;
                    data.Color = product.Color;
                    data.CategoryId = product.CategoryId;
                    data.BrandId = product.BrandId;

                    if (product.ProductImage != null)
                    {
                        data.Image = uniqueFileName;
                    }
                    _context.Update(data);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Edit successful product !";
                    return RedirectToAction(nameof(ListProductPhone));

                }
                catch (DbUpdateConcurrencyException)
                {
                    ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name", product.BrandId);
                    ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", product.CategoryId);
                    ViewData["TypeId"] = new SelectList(_context.TypeLaptop, "Id", "Name", product.TypeId);
                    if (!ProductExists(product.Id))
                    {
                        return View("/Views/Shared/ErrorAdmin.cshtml");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        private string UploadedFile(Product model)
        {
            string uniqueFileName = string.Empty;
            if (model.ProductImage != null)
            {
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Admin/assets/images/product");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProductImage.FileName;
                string filePath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProductImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public async Task<IActionResult> DetailsProductPhone(Guid? id)
        {
            if (id == null || _context.Product == null)
            {
                 return View("/Views/Shared/ErrorAdmin.cshtml");
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.TypeLaptop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return View("/Views/Shared/ErrorAdmin.cshtml"); 
            }
            return View(product);
        }

        public IActionResult CreateProductLaptop()
        {
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["TypeId"] = new SelectList(_context.TypeLaptop, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductLaptop(Product product)
        {
            try
            {
                string uniqueFileName = UploadedFile(product);
                product.Id = Guid.NewGuid();
                product.Image = uniqueFileName;
                _context.Add(product);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Create successful product !";
                return RedirectToAction(nameof(ListProductLaptop));
            }
            catch (Exception)
            {
                ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name", product.BrandId);
                ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", product.CategoryId);
                ViewData["TypeId"] = new SelectList(_context.TypeLaptop, "Id", "Name", product.TypeId);
                return View(product);
            }
        }

        public async Task<IActionResult> DetailsProductLaptop(Guid? id)
        {
            if (id == null || _context.Product == null)
            {
                return View("/Views/Shared/ErrorAdmin.cshtml");
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.TypeId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return View("/Views/Shared/ErrorAdmin.cshtml");
            }
            return View(product);
        }

        public async Task<IActionResult> EditLaptopProducts(Guid? id)
        {
            if (id == null || _context.Product == null)
            {
                return View("/Views/Shared/ErrorAdmin.cshtml");
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return View("/Views/Shared/ErrorAdmin.cshtml");
            }
            ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", product.CategoryId);
            ViewData["TypeId"] = new SelectList(_context.TypeLaptop, "Id", "Name", product.TypeId);

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditLaptopProducts(Guid id, Product product)
        {
            if (id != product.Id)
            {
                 return View("/Views/Shared/ErrorAdmin.cshtml");
            }
            else
            {
                try
                {
                    var data = await _context.Product.FindAsync(id);
                    string uniqueFileName = string.Empty;
                    if (product.ProductImage != null)
                    {
                        if (data.Id != null)
                        {
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Admin/assets/images/product", data.Image);
                            if (System.IO.File.Exists(filePath))
                            {
                                System.IO.File.Delete(filePath);
                            }
                        }
                        uniqueFileName = UploadedFile(product);
                    }
                    data.Name = product.Name;
                    data.Cpu = product.Cpu;
                    data.FrontCamera = product.FrontCamera;
                    data.BackCamera = product.BackCamera;
                    data.Sim = product.Sim;
                    data.Ram = product.Ram;
                    data.Storage = product.Storage;
                    data.OperatingSystem = product.OperatingSystem;
                    data.Feature = product.Feature;
                    data.Origin = product.Origin;
                    data.SizeVolume = product.SizeVolume;
                    data.Battery = product.Battery;
                    data.Quantity = product.Quantity;
                    data.YearOfManufacturer = product.YearOfManufacturer;
                    data.Price = product.Price;
                    data.Description = product.Description;
                    data.Color = product.Color;
                    data.CategoryId = product.CategoryId;
                    data.BrandId = product.BrandId;
                    if (product.ProductImage != null)
                    {
                        data.Image = uniqueFileName;
                    }
                    _context.Update(data);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Edit successful product !";
                    return RedirectToAction(nameof(ListProductPhone));

                }
                catch (DbUpdateConcurrencyException)
                {
                    ViewData["BrandId"] = new SelectList(_context.Brand, "Id", "Name", product.BrandId);
                    ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", product.CategoryId);
                    ViewData["TypeId"] = new SelectList(_context.TypeLaptop, "Id", "Name", product.TypeId);
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePhoneProduct(Guid id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                string deleteFromFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Admin/assets/images/product");
                string currentImage = Path.Combine(Directory.GetCurrentDirectory(), deleteFromFolder, product.Image);
                if (currentImage != null)
                {
                    if (System.IO.File.Exists(currentImage))
                    {
                        System.IO.File.Delete(currentImage);
                    }
                }
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Delete successful product !";        
            }
            return RedirectToAction(nameof(ListProductPhone));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteLaptopProduct(Guid id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                string deleteFromFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Admin/assets/images/product");
                string currentImage = Path.Combine(Directory.GetCurrentDirectory(), deleteFromFolder, product.Image);
                if (currentImage != null)
                {
                    if (System.IO.File.Exists(currentImage))
                    {
                        System.IO.File.Delete(currentImage);
                    }
                }
                _context.Product.Remove(product);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Delete successful product !";
            }
            return RedirectToAction(nameof(ListProductPhone));
        }

        [HttpPost]
        public async Task<IActionResult> SearchProductsPhone(string search)
        {
            if (_context.Product == null)
            {
                return View("/Views/Shared/ErrorAdmin.cshtml");
            }
            var model =await _context.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.TypeLaptop).Where(x=>x.Category.Name=="Điện thoại"&&x.Name.Contains(search)).ToListAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SearchProductsLaptop(string search)
        {
            if (_context.Product == null)
            {
                return View("/Views/Shared/ErrorAdmin.cshtml");
            }
            var model = await _context.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.TypeLaptop).Where(x => x.Category.Name == "Laptop" && x.Name.Contains(search)).ToListAsync();
            return View(model);
        }

        private bool ProductExists(Guid id)
        {
            return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
