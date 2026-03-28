using Microsoft.AspNetCore.Mvc;

namespace AS_Taranenko_lab1_gr1.Controllers
{

    public class OrderController : Controller
    {
        private readonly MyDbContext _dbContext;

        public OrderController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index(int? id)
        {
            if (id != null)
            {
                var Model = _dbContext.Orders
                    .Where(o => o.Id == id);
                return View(Model);
            }
            return NotFound();
        }
        public IActionResult Orders()
        {
            var Model = _dbContext.Orders.ToList();
            return View(Model);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var Model = _dbContext.Orders
                .FirstOrDefault(o => o.Id == id);
            if (Model == null)
                return NotFound();
            return View(Model);
        }

        [HttpPost]
        public IActionResult Delete(int? id, string decision)
        {
            if (id == null)
                return BadRequest();

            if (decision == "Accept")
            {
                var order = _dbContext.Orders.Find(id);

                if (order == null)
                    return NotFound();

                _dbContext.Orders.Remove(order);
                _dbContext.SaveChanges();
            }

            return RedirectToAction("Orders");
        }
    }
}
