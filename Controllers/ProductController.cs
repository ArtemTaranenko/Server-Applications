using AS_Taranenko_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

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

        public IActionResult Index(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(a => a.Id == id);

            return product is not null ? View(product) : ErrorView();
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
                return View("Added", product);
            }
            catch
            {
                return ErrorView();
            }

            
        }
    }
}
