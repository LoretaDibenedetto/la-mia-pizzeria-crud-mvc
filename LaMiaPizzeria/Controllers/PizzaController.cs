using LaMiaPizzeria.Database;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Mvc;




namespace LaMiaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
           using(PizzaContext db = new PizzaContext())
            {
                List<Pizza> ourPizza = db.Pizzas.ToList();
                return View(ourPizza);
            }
        }

         public IActionResult Details(int id)
            {
                using (PizzaContext db = new PizzaContext())
                
              {
                    Pizza? pizzaDetails = db.Pizzas.Where(article => article.Id == id).FirstOrDefault();


                  if (pizzaDetails != null)
                  {
                    return View("Details", pizzaDetails);
                  }
                  else
                  {
                    return NotFound($"L'articolo con id {id} non è stato trovato!");
                  }



            }

            }


                [HttpGet]
                public IActionResult Create()
                {
                    return View();
                }



                [HttpPost]
                [ValidateAntiForgeryToken]
                public IActionResult Create(Pizza newArticle)
                {
                    if (!ModelState.IsValid)
                    {
                        return View("Create", newArticle);
                    }

                    using (PizzaContext db = new PizzaContext())
                    {
                        db.Pizzas.Add(newArticle);
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }

        }
    }


















}
