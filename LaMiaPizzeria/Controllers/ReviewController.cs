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


        [HttpGet]
        public IActionResult Update(int id)
        {
          using (PizzaContext db = new PizzaContext()) 
            {
            Review? reviewToUpdate = db.Reviews.Where(review  => review.Id == id).FirstOrDefault();  

                if (reviewToUpdate == null)
                {
                    return NotFound();
                } 

                return View(reviewToUpdate);
              
            }
        
       
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, Review modifiedReview)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", modifiedReview);
            }

            using (PizzaContext db = new PizzaContext())
            {
                Review? reviewToModify = db.Reviews.Where(review => review.Id == id).FirstOrDefault();

                if (reviewToModify != null)
                {

                    reviewToModify.Name = modifiedReview.Name;
                    reviewToModify.Description = modifiedReview.Description;
                    

                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound("L'articolo da modificare non esiste!");
                }
            }

        }


        public IActionResult Delete(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                Review? reviewToDelete = db.Reviews.Where(review => review.Id == id).FirstOrDefault();

                if (reviewToDelete != null)
                {
                    db.Remove(reviewToDelete);
                    db.SaveChanges();

                    return RedirectToAction("Index");

                }
                else
                {
                    return NotFound("Non ho torvato la recensione da eliminare");

                }
            }
        }




    }
}
