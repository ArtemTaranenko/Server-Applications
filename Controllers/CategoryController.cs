using AS_Taranenko_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AS_Taranenko_lab1_gr1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MyDbContext _dbContext;

        public CategoryController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var allCategories = _dbContext.Categories.ToList();
            return View(allCategories);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            var isDuplicate = _dbContext.Categories.Any(c => c.Name == category.Name);

            if (isDuplicate)
            {
                ModelState.AddModelError("Name", "Taka kategoria już istnieje");
                return View(category); 
            }

            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            return View("Added", category);
        }
    }
}
