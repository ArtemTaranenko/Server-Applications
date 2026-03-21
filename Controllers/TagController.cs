using AS_Taranenko_lab1_gr1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AS_Taranenko_lab1_gr1.Controllers
{
    public class TagController : Controller
    {
        private readonly MyDbContext _dbContext;

        public TagController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var allTags = _dbContext.Tags.ToList();
            return View(allTags);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Tag tag)
        {
            _dbContext.Tags.Add(tag);
            _dbContext.SaveChanges();

            return View("Added", tag);
        }
    }
}
