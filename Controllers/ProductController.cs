using AS_Taranenko_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace AS_Taranenko_lab1_gr1.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyDbContext _dbContext;
        public ProductController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IActionResult ErrorView()
        => View("Error", new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });

        public IActionResult Index()
        {
            var model = new ProductViewModel()
            {
                Categories = _dbContext.Categories.ToList(),
                Tags = _dbContext.Tags.ToList(),
                Products = _dbContext.Products.ToList(),
            };

            return model is not null ? View(model) : ErrorView();
        }

        [HttpGet]
        public IActionResult Index(int? categoryId)
        {
            var products = _dbContext.Products.
                Include(p => p.Category).
                Include(p => p.Tags).
                AsQueryable();

            if (categoryId != null && categoryId.Value != 0)
            {
                products = products.Where(p => p.CategoryId == categoryId);
            }

            var model = new ProductViewModel()
            {

                Categories = _dbContext.Categories.ToList(),
                Tags = _dbContext.Tags.ToList(),
                Products = products.ToList(),
                SelectedCategoryId = categoryId,
            };

            return model is not null ? View(model) : ErrorView();
        }

        public IActionResult Details(int id)
        {
            var product = _dbContext.Products.
                Include(p => p.Category).
                Include(p => p.Tags).
                FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        public IActionResult Add()
        {
            ViewBag.categories = _dbContext.Categories
                .Select(a => new SelectListItem(a.Name, a.Id.ToString()))
                .ToList();

            ViewBag.tags = _dbContext.Tags
                .Select(a => new SelectListItem(a.Name, a.Id.ToString()))
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product, List<int> tags)
        {
            if (!ModelState.IsValid)
                return ErrorView();

            var productTags = tags != null ? _dbContext.Tags.Where(t => tags.Contains(t.Id)).ToList() : new List<Tag>();
            product.Tags = productTags;

            var category = _dbContext.Categories.FirstOrDefault(a => a.Id == product.CategoryId);
            if (category == null)
                return ErrorView();

            product.Category = category;

            _dbContext.Products.Add(product);

            try
            {
                _dbContext.SaveChanges();
                var model = _dbContext.Products.ToList();
                return View("ListProducts", model);
            }
            catch
            {
                return ErrorView();
            }

            
        }
    }
}
