using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AS_Taranenko_lab1_gr1.Models;

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

        public IActionResult ViewHistory(int? id)
        {
            if (id != null)
            {
                var Model = _dbContext.Orders
                    .Include(o => o.OrderStatusHistories)
                    .FirstOrDefault(o => o.Id == id);
                return View(Model);
            }
            return NotFound();
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

        private void LoadFormData()
        {
            ViewBag.CustomersList = _dbContext.Customers
                .Select(c => new SelectListItem(
                    c.Name,
                    c.Id.ToString()))
                .ToList();
            ViewBag.ItemsList = _dbContext.OrderItems
                .Select(i => new SelectListItem(
                    i.Product.Name,
                    i.Id.ToString()))
                .ToList();
            ViewBag.StatusList = _dbContext.OrderStatuses
                .Select(i => new SelectListItem(
                    i.Status.ToString(),
                    i.Id.ToString()
                    ));
        }

        public IActionResult AddOrUpdate(int? id)
        {
            LoadFormData();
            if (id.HasValue)
            {
                var order = _dbContext.Orders
                    .Include(o => o.Items)
                    .FirstOrDefault(o => o.Id == id.Value);
                if (order == null)
                    return NotFound();
                ViewBag.Header = "Edit Order";
                ViewBag.ButtonText = "Edit";
                ViewBag.SelectedItems = order.Items.Select(i => i.Id).ToList();

                return View(order);
            }

            ViewBag.Header = "Add order";
            ViewBag.ButtonText = "Add";
            ViewBag.SelectedItems = new List<int>();

            return View(new Order());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrUpdate(Order order, List<int> items)
        {
            LoadFormData();
            ViewBag.SelectedItems = items ?? new List<int>();
            foreach (var error in ModelState)
            {
                foreach (var subError in error.Value.Errors)
                {
                    Console.WriteLine($"{error.Key}: {subError.ErrorMessage}");
                }
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Header = order.Id == 0 ? "Add order" : "Edit order";
                ViewBag.ButtonText = order.Id == 0 ? "Add" : "Edit";
                return View(order);
            }

            var CustomerExists = _dbContext.Customers.Any(c => c.Id == order.CustomerId);
            if (!CustomerExists)
            {
                ModelState.AddModelError("CustomerId", "Selected customer does not exist");
                ViewBag.Header = order.Id == 0 ? "Add order" : "Edit order";
                ViewBag.ButtonText = order.Id == 0 ? "Add" : "Edit";
                return View(order);
            }

            var selectedItems = items != null
                ? _dbContext.OrderItems.Where(i => items.Contains(i.Id)).ToList()
                : new List<Order_Item>();

            if (order.Id == 0)
            {
                order.OrderStatusId = 1;
                order.CreatedAt = DateTime.Now;
                order.Items = selectedItems;

                _dbContext.Orders.Add(order);
            }
            else
            {
                var existingOrder = _dbContext.Orders
                    .Include(o => o.Items)
                    .FirstOrDefault(o => o.Id == order.Id);

                if (existingOrder == null)
                    return NotFound();
                existingOrder.OrderStatusId = order.OrderStatusId;
                existingOrder.CustomerId = order.CustomerId;
                existingOrder.Items?.Clear();
                foreach (var item in selectedItems)
                {
                    existingOrder.Items!.Add(item);
                }
            }

            try
            {
                _dbContext.SaveChanges();
                return RedirectToAction("Orders", "Order");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
