using Microsoft.AspNetCore.Mvc;
using PhaseEndProj.Models;

namespace PhaseEndProj.Controllers
{
    public class PizzaController : Controller
    {
        static public List<Pizza> pizzaMenu = new List<Pizza>() {

                new Pizza { PizzaId = 1,Type = "Onion and Capsicum", Price =120},
                new Pizza { PizzaId = 2,Type = "Cheesy",Price=150},
                new Pizza { PizzaId = 3,Type = "Tomato and Mushroom",Price=130}
            };
        static public List<OrderInfo> orderdetails = new List<OrderInfo>();


        public IActionResult Index()
        {
            return View(pizzaMenu);

        }


        public IActionResult Cart(int id)
        {
            var found = (pizzaMenu.Find(p => p.PizzaId == id));

            TempData["id"] = id;

            return View(found);

        }
        [HttpPost]
        public IActionResult Cart(IFormCollection f)
        {
            Random r = new Random();
            int id = Convert.ToInt32(TempData["id"]);
            OrderInfo o = new OrderInfo();
            var found = (pizzaMenu.Find(p => p.PizzaId == id));
            o.OrderId = r.Next(100, 999);
            o.PizzaId = id;
            o.Price = found.Price;
            o.Type = found.Type;
            o.Quantity = Convert.ToInt32(Request.Form["qty"]);
            o.TotalPrice = o.Price * o.Quantity;

            orderdetails.Add(o);

            return RedirectToAction("Checkout");

        }


        public IActionResult Checkout()
        {

            return View(orderdetails);

        }

        public IActionResult Confirmation()
        {
            return View();

        }


    }
}