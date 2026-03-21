using Microsoft.AspNetCore.Mvc;
using AS_Taranenko_lab1_gr1.Models;

namespace AS_Taranenko_lab1_gr1.Controllers
{
    public class AdressController : Controller
    {
        private readonly MyDbContext _dbContext;
        public AdressController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var allAdresses = _dbContext.Adresses.ToList();
            return View(allAdresses);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Adress adress)
        {
            _dbContext.Adresses.Add(adress);
            _dbContext.SaveChanges();
            return View("Added", adress);
        }
    }
}
