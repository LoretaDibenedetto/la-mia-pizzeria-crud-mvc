using LaMiaPizzeria.Database;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            using(PizzaContext db =  new PizzaContext())
            {
                List<Review> reviews = db.Reviews.ToList();
                return View(reviews);
            }
        }
    }
}
