 using ASP.NETCORE_PROJECT.Areas.Identity.Data;
using ASP.NETCORE_PROJECT.Models;
using ASP.NETCORE_PROJECT.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace ASP.NETCORE_PROJECT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public int PageSize = 6;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _context.Category.ToListAsync();
            List<Product> productsPhone = await _context.Product.Where(x=>x.Category.Name=="Điện thoại").OrderByDescending(x=>x.Price).Take(4).ToListAsync();            
            List<Product> productsLaptop = await _context.Product.Where(x => x.Category.Name == "Laptop").Take(4).ToListAsync();
            List<Product> productsTablet = await _context.Product.Where(x => x.Category.Name == "Máy tính bảng").ToListAsync();
            List<Product> productsSmartWatch = await _context.Product.Where(x => x.Category.Name == "Đồng hồ thông minh").ToListAsync();            
            List<Product> listSamsung = await _context.Product.Where(x => x.Brand.Name == "Samsung").Take(4).ToListAsync();
            ViewBag.ListSamsung = listSamsung;
            ViewBag.ProductsLaptop = productsLaptop;
            ViewBag.ProductsTablet = productsTablet;
            ViewBag.ProductsSmartWatch = productsSmartWatch;           
            ViewBag.Categories= categories;
            ViewBag.ProductsPhone= productsPhone;
            ViewBag.Categories = categories;
            return View();
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Product == null)
            {
                return View("/Views/Shared/Error.cshtml");
            }
            List<Comment> comments = _context.Comment.ToList();
            ViewBag.Comments = comments;
            var listUser = await _context.Users.ToListAsync();
            ViewBag.ListUser = listUser;
            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.TypeLaptop)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
       
        public async Task<IActionResult> ListProductsByCategory(Guid? id,string? linkContent)        
        {
            if(id==null || _context.Product==null)
            {
                return View("/Views/Shared/Error.cshtml");
            }
            var cateName = _context.Category.FirstOrDefault(x => x.Id == id);
            var productCount = _context.Product.Where(x => x.CategoryId == id).ToList().Count();
            ViewBag.CateName = cateName.Name;
            ViewBag.CateId=cateName.Id;
            ViewBag.ProductCount = productCount;
           
            if (linkContent=="Giá thấp")
            {
                ViewBag.LinkContent = linkContent;
                var shortPriceDesc= await _context.Product.Where(x => x.Id==id).OrderBy(x=>x.Price).ToListAsync();
                return View(shortPriceDesc);
            }
            if (linkContent == "Giá cao")
            {
                ViewBag.LinkContent = linkContent;
                var shortPrice = await _context.Product.Where(x => x.Id == id).OrderByDescending(x => x.Price).ToListAsync();
                return View(shortPrice);
            }         
            var model = await _context.Product.Where(x => x.CategoryId == id).ToListAsync();           
            return View(model);                         
        }

        public async Task<IActionResult> ListSamsungProducts(string? linkContent)
        {
            if (linkContent == "Giá thấp")
            {
                var shortPriceDesc = await _context.Product.Where(x => x.Brand.Name == "Samsung").OrderBy(x => x.Price).ToListAsync();
                ViewBag.SamsungProductsCount=shortPriceDesc.Count;
                return View(shortPriceDesc);
            }
            if (linkContent == "Giá cao")
            {
                var shortPrice = await _context.Product.Where(x => x.Brand.Name == "Samsung").OrderByDescending(x => x.Price).ToListAsync();
                ViewBag.SamsungProductsCount=shortPrice.Count;
                return View(shortPrice);
            }
            var model = await _context.Product.Where(x => x.Brand.Name == "Samsung").ToListAsync();
            ViewBag.SamsungProductsCount=model.Count;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchProducts(string product_name)
        {
            ViewBag.SearchName = product_name;
            var model = await _context.Product.Where(x => x.Name.Contains(product_name)).ToListAsync();
            ViewBag.Quantity = model.Count();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult GetFilteredProducts([FromBody] FilterData filterData)
        {
            var filteredProducts=_context.Product.ToList();
            if(filterData.PriceRange != null &&filterData.PriceRange.Count > 0 && !filterData.PriceRange.Contains("all"))
            {
                List<PriceRange> priceRanges = new List<PriceRange>();
                foreach (var item in filterData.PriceRange)
                {
                    var value = item.Split("-").ToArray();
                    PriceRange priceRange = new PriceRange();
                    priceRange.MinPrice = Int64.Parse(value[0]);
                    priceRange.MaxPrice = Int64.Parse(value[1]);
                    priceRanges.Add(priceRange);
                }
                filteredProducts = filteredProducts.Where(x => priceRanges.Any(r => x.Price >= r.MinPrice && x.Price <= r.MaxPrice)).OrderBy(x=>x.Price).ToList();

            }
            return PartialView("_ReturnProducts",filteredProducts);
        }

        public async Task<IActionResult> ListPhoneProducts(string? linkContent)
        {
            if (linkContent == "Giá thấp")
            {
                var shortPriceDesc = await _context.Product.Where(x => x.Category.Name == "Điện thoại").OrderBy(x => x.Price).ToListAsync();
                ViewBag.PhoneCount = shortPriceDesc.Count();
                return View(shortPriceDesc);
            }
            if (linkContent == "Giá cao")
            {
                var shortPrice = await _context.Product.Where(x => x.Category.Name == "Điện thoại").OrderByDescending(x => x.Price).ToListAsync();
                ViewBag.PhoneCount = shortPrice.Count();
                return View(shortPrice);
            }
            var model = await _context.Product.Where(x=>x.Category.Name =="Điện thoại").ToArrayAsync();
            ViewBag.PhoneCount = model.Count();
            return View(model);
        }

        public async Task<IActionResult> ListLaptopProducts(string? linkContent)
        {
            if (linkContent == "Giá thấp")
            {
                var shortPriceDesc = await _context.Product.Where(x => x.Category.Name == "Laptop").OrderBy(x => x.Price).ToListAsync();
                ViewBag.LaptopCount=shortPriceDesc.Count();
                return View(shortPriceDesc);
            }
            if (linkContent == "Giá cao")
            {
                var shortPrice = await _context.Product.Where(x => x.Category.Name == "Laptop").OrderByDescending(x => x.Price).ToListAsync();
                ViewBag.LaptopCount=shortPrice.Count();
                return View(shortPrice);
            }
            var model = await _context.Product.Where(x => x.Category.Name == "Laptop").ToArrayAsync();
            ViewBag.LaptopCount = model.Count();
            return View(model);
        }

    }
}