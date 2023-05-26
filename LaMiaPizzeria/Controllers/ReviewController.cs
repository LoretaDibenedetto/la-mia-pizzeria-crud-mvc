using LaMiaPizzeria.Database;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                List<Review> reviews = db.Reviews.ToList();
                return View(reviews);
            }
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Review review)
        {
            if(!ModelState.IsValid)
            {
                return View("Create" ,review);
            }
            using (PizzaContext db = new PizzaContext())
            {
                Review reviewToCreate = new Review();
                reviewToCreate.Name = review.Name;
                reviewToCreate.Description = review.Description;    
                db.Reviews.Add(reviewToCreate);
                db.SaveChanges();   
                return RedirectToAction("Index");   
            }
        
        }













    }
}
