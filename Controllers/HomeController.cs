using Microsoft.AspNetCore.Mvc;
using AS_Taranenko_lab1_gr1.Models;

namespace AS_Taranenko_lab1_gr1.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _dbContext;
        public HomeController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            var model = new HomeViewModel
            {

                Categories = (ICollection<Category>)_dbContext.Categories.ToList(),
                Tags = (ICollection<Tag>)_dbContext.Tags.ToList(),
                Adresses = (ICollection<Adress>)_dbContext.Adresses.ToList(),
                Products = (ICollection<Product>)_dbContext.Products.ToList()


            };

            return View(model);
        }
    }
}
